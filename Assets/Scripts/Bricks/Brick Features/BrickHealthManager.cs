using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHealthManager
{
    public event Action<int> OnBreak;

    [SerializeField]
    private int _maxHealth;
    private int _currentHealth;
    private int _score;

	public BrickHealthManager(int score)
    {
        _currentHealth = _maxHealth;
        _score = score;
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
        OnBreak?.Invoke(_score);
    }
}