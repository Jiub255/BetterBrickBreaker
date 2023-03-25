using UnityEngine;

public class BallBouncer
{
    public BallBouncer()
	{
	}

    // Called from OnCollisionEnter2D in BallMovementManager. 
    public Vector2 HandleBounce(Collision2D collision, Vector2 velocity)
    {
        // Use IBounceEffect interface here. 
        Vector2 bounceVelocity = collision.gameObject.GetComponent<IBounceEffect>().CalculateBounce(velocity, collision.GetContact(0).point);

        return bounceVelocity;
    }
}