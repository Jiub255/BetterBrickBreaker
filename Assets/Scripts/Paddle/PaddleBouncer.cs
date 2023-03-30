using UnityEngine;

public class PaddleBouncer
{
    private float _minAngle;

    public PaddleBouncer(float minAngle)
    {
        _minAngle = minAngle;
    }

    // Bounces the ball away at an angle that only depends on where on the paddle the ball hit. 
    // Keeps the same speed as it had on impact. 
    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint, Transform paddleTransform)
    {
        // Find out where the ball hit the paddle in local space (-0.5 to 0.5).
        Vector2 localSpaceImpactPoint = paddleTransform.InverseTransformPoint(worldSpaceImpactPoint);
        // Debug.Log($"localSpaceImpactPoint: {localSpaceImpactPoint}");

        // Store speed.
        float speed = impactVelocity.magnitude;
        // Debug.Log($"speed: {speed}");

        // Get bounce angle based off impact position. 
        // Far right bounces off at (180 - _maxAngle) degrees, far left at _maxAngle degrees. 
        float bounceAngle = (2 * _minAngle - 180) * localSpaceImpactPoint.x + 90;
       // Debug.Log($"bounceAngle: {bounceAngle}");

        // Make new Vector2 in the bounce angle's direction. 
        Vector2 bounceDirection = new Vector2(Mathf.Cos(bounceAngle * Mathf.Deg2Rad), Mathf.Sin(bounceAngle * Mathf.Deg2Rad));
       //  Debug.Log($"bounceDirection: {bounceDirection}");

        // Multiply direction by speed to get final bounce velocity. 
        Vector2 bounceVelocity = speed * bounceDirection; 
       //  Debug.Log($"bounceVelocity: {bounceVelocity}");

        return bounceVelocity;
    }
}