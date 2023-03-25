using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour, IBounceEffect
{
    public static event Action<int> OnBrickBroken;

    private BrickBouncer _brickBouncer;
    private BrickHealthManager _brickHealthManager;

    private BoxCollider2D _boxCollider;

    [SerializeField]
    private int _points = 1;

    private void OnEnable()
    {
        _boxCollider = GetComponent<BoxCollider2D>();

        _brickBouncer = new BrickBouncer(transform, _boxCollider);
        _brickHealthManager = new BrickHealthManager(_points);

        _brickHealthManager.OnBreak += OnBreakBrick;
    }

    private void OnDisable()
    {
        _brickHealthManager.OnBreak -= OnBreakBrick;
    }

    private void OnBreakBrick(int score)
    {
        // GameManager listens, increases score. HUD Updates. 
        OnBrickBroken?.Invoke(score);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _brickHealthManager.TakeDamage();
    }

    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint)
    {
        // Probably being silly with architecture at this point.  
        return _brickBouncer.CalculateBounce(impactVelocity, worldSpaceImpactPoint);


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