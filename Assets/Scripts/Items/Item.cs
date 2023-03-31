using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float FallSpeed = 5f;
    private Rigidbody2D _rb;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public abstract void ApplyEffect(Paddle paddle);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Paddle paddle = collision.gameObject.GetComponent<Paddle>();
        if (paddle != null)
        {
            ApplyEffect(paddle);
        }
    }

    private void FixedUpdate()
    {
		_rb.MovePosition(_rb.position + Vector2.down * FallSpeed * Time.fixedDeltaTime);
    }
}