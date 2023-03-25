using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovementManager : MonoBehaviour
{
	private Rigidbody2D _rb;
	private Vector2 _velocity;
    [SerializeField]
    private Vector2 _launchVelocity = new Vector2(1f, 2f).normalized * 10f;

	private BallBouncer _ballBounceMan2;
	private BallMover _ballMovement2;

    private bool _ballOnPaddle = true;

    private Transform _ballHolderTransform;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _velocity = Vector2.zero;
        _ballOnPaddle = true;
        _ballHolderTransform = transform.parent;

        _ballBounceMan2 = new BallBouncer();
        _ballMovement2 = new BallMover(_rb);
    }

    private void Start()
    {
        S.I.IM.PC.Gameplay.Action.performed += LaunchBall;

        GameManager.OnResetBall += ResetBall;
    }

    private void OnDisable()
    {
        S.I.IM.PC.Gameplay.Action.performed -= LaunchBall;

        GameManager.OnResetBall -= ResetBall;
    }

    private void ResetBall()
    {
        // Parent ball to ball holder (which is a child of the paddle). 
        transform.parent = _ballHolderTransform;

        // Reset ball's position.
        transform.localPosition = Vector2.zero;

        // Set rigidbody to kinematic so ball moves with paddle.
        _rb.bodyType = RigidbodyType2D.Kinematic;

        _velocity = Vector2.zero;

        _ballOnPaddle = true;
    }

    private void LaunchBall(InputAction.CallbackContext context)
    {
        if (_ballOnPaddle)
        {
            // Unparent ball from paddle. 
            transform.parent = null;

            // Set rigidbody to dynamic so collisions work.
            _rb.bodyType = RigidbodyType2D.Dynamic;

            _velocity = _launchVelocity;

            _ballOnPaddle = false;
        }
    }

    private void FixedUpdate()
    {
        if (!_ballOnPaddle)
        {
            _ballMovement2.TickPosition(_velocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _velocity = _ballBounceMan2.HandleBounce(collision, _velocity);
    }
}