using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBouncer : IBounceEffect
{
    private Transform _brickTransform;
    private BoxCollider2D _boxCollider;

	public BrickBouncer(Transform brickTransform, BoxCollider2D boxCollider)
    {
        _brickTransform = brickTransform;
        _boxCollider = boxCollider;
    }

    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint)
    {
        // If impact point is close to the side endpoints, reverse x velocity,
        // otherwise, reverse y velocity. 
        Vector2 localSpaceImpactPoint = _brickTransform.InverseTransformPoint(worldSpaceImpactPoint);

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