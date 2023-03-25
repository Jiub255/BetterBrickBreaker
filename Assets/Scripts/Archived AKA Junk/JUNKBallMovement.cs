using UnityEngine;

public class JUNKBallMovement : MonoBehaviour
{
/*	private Rigidbody2D _rb;

    // Necessary or useful to separate speed and direction?
    private Vector2 _direction;
    private float _speed;

    private Vector2 _velocity;*//* { get { return _speed * _direction; } }*//*

    public Vector2 Velocity { get { return _velocity; } }

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();

        JUNKBallBounceManager.OnChangedVelocity += ChangeVelocity;

        // JUST FOR TESTING!!!
        _velocity = new Vector2(0.7071f, -0.7071f);
    }

    private void OnDisable()
    {
        JUNKBallBounceManager.OnChangedVelocity -= ChangeVelocity;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
    }

    // These get called from collision events with bricks/paddles/walls. 
    private void ChangeVelocity(Vector2 newVelocity)
    {
        _velocity = newVelocity;
    }

    // Necessary or useful to separate speed and direction?
    private void ChangeDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }

    private void ChangeSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }*/
}