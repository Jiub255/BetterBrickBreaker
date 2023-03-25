using UnityEngine;

public class SideWall : MonoBehaviour, IBounceEffect
{
    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint)
    {
        // Just reverse the x-component of the velocity. 
        Vector2 bounceVelocity = new Vector2(-impactVelocity.x, impactVelocity.y);

        return bounceVelocity;
    }
}