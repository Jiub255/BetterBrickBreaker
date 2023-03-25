using System;
using UnityEngine;

public class JUNKBallBounceManager : MonoBehaviour
{
    // BallMovement listens for this. 
    public static event Action<Vector2> OnChangedVelocity;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // Use IBounceEffect interface here. 
        // TODO: How to get BallMovement.Velocity here? In a good way that is. 
        Vector2 bounceVelocity = collision.gameObject.GetComponent<IBounceEffect>().CalculateBounce(new Vector2(0.7071f, -0.7071f), collision.GetContact(0).point);

        // BallMovement listens for this. 
        OnChangedVelocity?.Invoke(bounceVelocity);
    }
}