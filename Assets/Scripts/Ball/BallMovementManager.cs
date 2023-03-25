using UnityEngine;

public class BallMovementManager : MonoBehaviour
{
	private Rigidbody2D _rb;
	private Vector2 _velocity;

	private BallBouncer _ballBounceMan2;
	private BallMover _ballMovement2;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();

        // JUST FOR TESTING!
        _velocity = new Vector2(2f, -2f);

        _ballBounceMan2 = new BallBouncer();
        _ballMovement2 = new BallMover(_rb);
    }

    private void FixedUpdate()
    {
        _ballMovement2.TickPosition(_velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _velocity = _ballBounceMan2.HandleBounce(collision, _velocity);
    }
}