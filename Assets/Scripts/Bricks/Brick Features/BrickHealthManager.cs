using System;
using UnityEngine;

public class BrickHealthManager
{
    public event Action<int> OnBreak;

    private int _currentHealth;
    private int _points;

	public BrickHealthManager(int maxHealth, int points)
    {
        _currentHealth = maxHealth;
        _points = points;
    }

    public void TakeDamage()
    {
        _currentHealth -= 1;

       // Debug.Log($"TakeDamage called, current health now {_currentHealth}");

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Break();
        }
    }

    private void Break()
    {
        // BrickManager, HUD Manager listen. 
        OnBreak?.Invoke(_points);
    }
}