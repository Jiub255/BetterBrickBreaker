using System;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    public static event Action OnBallFall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BallMovementManager>() != null)
        {
            // Game Manager listens, handles life loss, then goes from there. 
            OnBallFall?.Invoke();
        }
    }
}