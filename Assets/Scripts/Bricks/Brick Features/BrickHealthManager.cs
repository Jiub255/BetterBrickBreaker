using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHealthManager
{
    public event Action OnBreak;

    [SerializeField]
    private int _maxHealth;
    private int _currentHealth;

	public BrickHealthManager()
    {
        _currentHealth = _maxHealth;
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
        // Who listens? 
        OnBreak?.Invoke();
    }
}