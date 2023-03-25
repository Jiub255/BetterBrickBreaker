using UnityEngine;

public interface IBounceEffect
{
	public abstract Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint);
}