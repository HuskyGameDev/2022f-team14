using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject pickupEffect;

    [SerializeField] private int healAmount;
    [SerializeField] private float speedMultiplier = 1.3f;
    [SerializeField] private int effectDurationInSeconds = 3;

    enum PowerupType
    {
        RestoreHealth,
        SpeedBoost
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
        switch (_powerupType)
        {
            case PowerupType.RestoreHealth:
                PlayerDamage playerDmg = player.gameObject.GetComponent<PlayerDamage>();
                playerDmg.playerHeal(healAmount);
                Destroy(gameObject);
                break;
            case PowerupType.SpeedBoost:
                StartCoroutine(MultiplySpeed(player));
                break;
            default:
                break;
        }
    }
    
    private IEnumerator MultiplySpeed(Component player)
    {
        PlayerController controller = player.gameObject.GetComponent<PlayerController>();

        SpriteRenderer visual = GetComponent<SpriteRenderer>();
        visual.enabled = false;
        
        controller.speed *= speedMultiplier;
        yield return new WaitForSeconds(effectDurationInSeconds);
        controller.speed /= speedMultiplier;
        
        Destroy(gameObject);
    }
}
