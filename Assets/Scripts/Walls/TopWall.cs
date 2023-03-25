using UnityEngine;

public class TopWall : MonoBehaviour, IBounceEffect
{
    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint)
    {
        // Just reverse the y-component of the velocity. 
        Vector2 bounceVelocity = new Vector2(impactVelocity.x, -impactVelocity.y);

        return bounceVelocity;
    }
}