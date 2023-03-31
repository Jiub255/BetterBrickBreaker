using System;
using UnityEngine;

public class Brick : MonoBehaviour, IBounceEffect
{
    public static event Action<int> OnBrickBroken;

    private BrickHealthManager _brickHealthManager;
    [SerializeField]
    private bool _indestructible = false;
    [SerializeField]
    private int _maxHealth = 1;
    [SerializeField]
    private int _points = 1;
    [SerializeField]
    private BrickColorsSO _brickColorsSO;
    private SpriteRenderer _spriteRenderer;

    private BrickBouncer _brickBouncer;
    private BoxCollider2D _boxCollider;

    public bool Indestructible { get { return _indestructible; } }

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _brickBouncer = new BrickBouncer(transform, _boxCollider);

        if (!_indestructible)
        {
            _brickHealthManager = new BrickHealthManager(_maxHealth, _points, _brickColorsSO, _spriteRenderer);
            _brickHealthManager.OnBreak += OnBreakBrick;
        }
    }

    private void OnDisable()
    {
        if (!_indestructible)
        {
            _brickHealthManager.OnBreak -= OnBreakBrick;
        }
    }

    private void OnBreakBrick(int points)
    {
        // GameManager listens, increases score. HUD Updates. 
        // LevelManager listens, subtracts one from brick count. 
        OnBrickBroken?.Invoke(points);

        Destroy(gameObject);
    }

    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint)
    {
      //  Debug.Log($"BrickManager box collider: {_boxCollider}, extents: {_boxCollider.bounds.extents}, size: {_boxCollider.bounds.size}");

        // Probably being silly with architecture at this point.  
        Vector2 bounceVelocity = _brickBouncer.CalculateBounce(impactVelocity, worldSpaceImpactPoint);

        if (!_indestructible)
        {
            // Do this last because it could result in the brick being destroyed. 
            _brickHealthManager.TakeDamage();
        }

        return bounceVelocity;

/*        // If impact point is close to the side endpoints, reverse x velocity,
        // otherwise, reverse y velocity. 
        Vector2 localSpaceImpactPoint = transform.InverseTransformPoint(worldSpaceImpactPoint);

        // Get side end points of collider.
        float xExtent = _boxCollider.bounds.extents.x;

        Debug.Log($"Impact x-coordinate: {localSpaceImpactPoint.x}, x-extent of collider: {xExtent}");

        // If collision happened on the left or right end, 
        if (localSpaceImpactPoint.x < -xExtent + 0.00001f || localSpaceImpactPoint.x > xExtent - 0.00001f)
        {
            // Reverse x-velocity.
            return new Vector2(-impactVelocity.x, impactVelocity.y);
        }
        // If collision happened on the top or bottom, 
        else
        {
            // Reverse y-velocity. 
            return new Vector2(impactVelocity.x, -impactVelocity.y);
        }*/
    }
}