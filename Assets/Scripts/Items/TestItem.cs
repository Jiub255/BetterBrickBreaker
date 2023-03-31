using UnityEngine;

public class TestItem : Item
{
    public override void ApplyEffect(Paddle paddle)
    {
        Debug.Log("Test Item effect applied.");
    }
}