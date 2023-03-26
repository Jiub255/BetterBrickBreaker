using System;
using UnityEngine;

public class BrickHealthManager
{
    public event Action<int> OnBreak;

    [SerializeField]
    private int _maxHealth;
    private int _currentHealth;
    private int _points;

	public BrickHealthManager(int points)
    {
        _currentHealth = _maxHealth;
        _points = points;
    }

    public void TakeDamage()
    {
        _currentHealth -= 1;
        if (_currentHealth < 0)
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