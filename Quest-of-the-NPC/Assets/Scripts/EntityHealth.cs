using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth
{
    // Fields
    int _currentHealth;
    int _currentMaxHealth;
    int _currentMinHealth;

    // Properties
    // The amount of health an entity has
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    // The maximum amount of health an entity can have
    public int maxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    // The minimum amount of health an entity can have.
    // This is a variable instead of zero in the event that we implement something
    // That temporarily keeps the player from dying
    public int minHealth
    {
        get
        {
            return _currentMinHealth;
        }
        set
        {
            _currentMinHealth = value;
        }
    }

    // Constructor
    public EntityHealth(int health, int maxHealth, int minHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
        _currentMinHealth = minHealth;
    }

    // Method for subtracting health
    public void dmgEntity(int dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    // Method for adding health. Sets health back to max if healing causes health to exceed max
    public void healEntity(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
