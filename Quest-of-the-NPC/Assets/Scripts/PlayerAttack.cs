using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCoolDown;
    [SerializeField] public float attackTime;

    [SerializeField] public Transform attackDirection;
    public LayerMask canBreak;

    [SerializeField] public float attackArea;
    [SerializeField] public int damage;

    // Update is called once per frame
    void FixedUpdate()
    {
        //if sufficient time has passed
        if (attackCoolDown <= 0)
        {
            //melee button press
            if (Input.GetKey(KeyCode.Space))
            {
                //apply damage to all enemies or breakable objects in range
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackDirection.position, attackArea, canBreak);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<enHealth>().takeDamage(damage);
                }
                //reset timer
                attackCoolDown = attackTime;
            }
        }
        else 
        {
            //adjust timer
            attackCoolDown -= Time.deltaTime;
        }
    }
}
