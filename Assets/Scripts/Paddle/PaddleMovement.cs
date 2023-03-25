using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement
{
	private Rigidbody2D _rb;
    private float _topSpeed;
    private float _timeToTopSpeed;

    private InputAction _moveAction;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _smoothedMovementInputVelocity;

    public PaddleMovement(Rigidbody2D rb, float topSpeed, float timeToTopSpeed)
    {
        _rb = rb;
        _topSpeed = topSpeed;
        _timeToTopSpeed = timeToTopSpeed;
    }

    public void InitializeInput()
    {
        _moveAction = S.I.IM.PC.Gameplay.Move;
    }

    public void GetMovementInput()
    {
        _movementInput = new Vector2(_moveAction.ReadValue<float>(), 0f);
        SmoothMovementInput();
    }

    private void SmoothMovementInput()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput, 
            _movementInput, 
            ref _smoothedMovementInputVelocity,
            _timeToTopSpeed);
    }

    public void UpdatePosition()
    {
        Vector2 desiredPosition = _rb.position + (_smoothedMovementInput * _topSpeed * Time.fixedDeltaTime);

        _rb.MovePosition(desiredPosition);
    }
}