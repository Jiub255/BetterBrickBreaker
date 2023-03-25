using UnityEngine;

public class PaddleManager : MonoBehaviour, IBounceEffect
{
    private PaddleMovement _paddleMovement;
    private PaddleBouncer _paddleBouncer;

    private Rigidbody2D _rb;
    [SerializeField, Range(0f, 30f)]
    private float _topSpeed = 10f;
    [SerializeField, Range(0f, 1f)]
    private float _timeToTopSpeed = 0.15f;

    [SerializeField, Range(15f, 80f), Tooltip("Ball will bounce off paddle at an angle between (180 - min angle) and min angle.")]
    private float _minAngle = 45f;

    private void OnEnable()
    {
       _rb = GetComponent<Rigidbody2D>();

        _paddleMovement = new PaddleMovement(_rb, _topSpeed, _timeToTopSpeed);
        _paddleBouncer = new PaddleBouncer(_minAngle);
    }

    private void Start()
    {
        _paddleMovement.InitializeInput();
    }

    private void Update()
    {
        _paddleMovement.GetMovementInput();
    }

    private void FixedUpdate()
    {
        _paddleMovement.UpdatePosition();
    }

    public Vector2 CalculateBounce(Vector2 impactVelocity, Vector2 worldSpaceImpactPoint)
    {
        return _paddleBouncer.CalculateBounce(impactVelocity, worldSpaceImpactPoint, transform);
    }
}