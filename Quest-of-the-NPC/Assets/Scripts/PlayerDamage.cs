using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public HealthBar healthBar;
    [SerializeField] private int damagePerClick;
    [SerializeField] private int healPerClick;

    void Start()
    {
        healthBar.SetMaxHealth(GameManager.gameManager._playerHealth.maxHealth);
    }

    void Update()
    {
        // Player takes damage on key press. To be changed to enemy contact later.
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerTakeDmg(damagePerClick);
            //Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        // Player gains health on key press. To be changed to healing items later.
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerHeal(healPerClick);
            //Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }



    // Called from playerTakeDmg update above. Calls dmgEntity for the player and subtracts from health
    private void playerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.dmgEntity(dmg);
        
        // Update healthbar
        healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
        
        // Create popup
        DamagePopup.Create(transform.position, damagePerClick, false, false);
    }

    // Called from playerTakeDmg update above. Calls healEntity for the player and adds to health
    private void playerHeal(int heal)
    {
        GameManager.gameManager._playerHealth.healEntity(heal);
        
        // Update healthbar
        healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
        
        // Create popup
        DamagePopup.Create(transform.position, healPerClick, false, true);
    }
}
