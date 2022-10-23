using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthBar : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private int health;
    [SerializeField] private int damagePerSpace;
    [SerializeField] private int healPerSpace;

    private int curHealth;
    
    void Start()
    {
        curHealth = health;
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(damagePerSpace);
            DamagePopup.Create(FindObjectOfType<PlayerController>().transform.position, damagePerSpace, false, false);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Heal(healPerSpace);
            DamagePopup.Create(FindObjectOfType<PlayerController>().transform.position, healPerSpace, false, true);
        }
    }

    private void TakeDamage(int damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            curHealth = 0;
        }
        healthBar.SetHealth(curHealth);
    }

    private void Heal(int healAmount)
    {
        curHealth += healAmount;
        if (curHealth >= health)
        {
            curHealth = health;
        }
        healthBar.SetHealth(curHealth);
    }
}
