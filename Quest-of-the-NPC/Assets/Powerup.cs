using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject pickupEffect;

    [SerializeField] private int healAmount;

    enum PowerupType
    {
        RestoreHealth
    }

    [SerializeField] private PowerupType _powerupType;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        // Spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        
        // Apply effect to player
        PlayerDamage playerDmg = player.gameObject.GetComponent<PlayerDamage>();
        switch (_powerupType)
        {
            case PowerupType.RestoreHealth:
                playerDmg.playerHeal(healAmount);
                break;
            default:
                break;
        }

        // Remove powerup object
        Destroy(gameObject);
    }
}
