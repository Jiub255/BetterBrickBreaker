using System;
using UnityEngine;

public class BrickHealthManager
{
    public event Action<int> OnBreak;

    private int _currentHealth;
    private int _points;
    private BrickColorsSO _brickColorsSO;
    private SpriteRenderer _spriteRenderer;

	public BrickHealthManager(int maxHealth, int points, BrickColorsSO brickColorsSO, SpriteRenderer spriteRenderer)
    {
        _currentHealth = maxHealth;
        _points = points;
        _brickColorsSO = brickColorsSO;
        _spriteRenderer = spriteRenderer;

        // Change brick color to corresponding color from _brickColorsSO, based on brick's health. 
        SetBrickColor();
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
        else
        {
            // Change brick color to corresponding color from _brickColorsSO, based on brick's health. 
            SetBrickColor();
        }
    }

    private void SetBrickColor()
    {
        _spriteRenderer.color = _brickColorsSO.Colors[_currentHealth - 1];
    }

    private void Break()
    {
        // BrickManager, HUD Manager listen. 
        OnBreak?.Invoke(_points);
    }
}