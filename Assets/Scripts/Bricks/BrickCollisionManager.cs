using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollisionManager : MonoBehaviour, IBounceEffect
{
    private BrickBouncer _brickBouncer;
    private BrickHealthManager _brickHealthManager;
    private BoxCollider2D _boxCollider;

    private void OnEnable()
    {
        _brickBouncer = new BrickBouncer();
        _brickHealthManager = new BrickHealthManager();

        _boxCollider = GetComponent<BoxCollider2D>();

        _brickHealthManager.OnBreak += () => { Destroy(gameObject); };
    }

    private void OnDisable()
    {
        _brickHealthManager.OnBreak -= () => { Destroy(gameObject); };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        _brickHealthManager.TakeDamage();
    }

    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint)
    {
        // If impact point is close to the side endpoints, reverse x velocity,
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
        }
    }
}