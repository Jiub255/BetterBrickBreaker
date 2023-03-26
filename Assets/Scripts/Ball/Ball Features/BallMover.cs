using UnityEngine;

public class BallMover
{
	private Rigidbody2D _rb;

	public BallMover(Rigidbody2D rb)
    {
		_rb = rb;
    }

	// Called from FixedUpdate in BallController. 
	public void TickPosition(Vector2 velocity)
	{
		_rb.MovePosition(_rb.position + velocity * Time.fixedDeltaTime);
	}
}