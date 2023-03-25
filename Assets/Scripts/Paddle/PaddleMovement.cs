using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
	private Rigidbody2D _rb;
    private InputAction _moveAction;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _smoothedMovementInputVelocity;
    [SerializeField, Range(0f, 1f)]
    private float _timeToTopSpeed = 0.15f;
    [SerializeField, Range(0f, 30f)]
    private float _topSpeed = 10f;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _moveAction = S.I.IM.PC.Gameplay.Move;
    }

    private void Update()
    {
        _movementInput = new Vector2(_moveAction.ReadValue<float>(), 0f);
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput, 
            _movementInput, 
            ref _smoothedMovementInputVelocity,
            _timeToTopSpeed);
    }

    private void FixedUpdate()
    {
        Vector2 desiredPosition = _rb.position + (_smoothedMovementInput * _topSpeed * Time.fixedDeltaTime);

        _rb.MovePosition(desiredPosition);
    }
}