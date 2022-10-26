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
    public int face;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        directionalOffset(1);
        directionalOffset(0);
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

    //adjust poition of melee sphere according to player direction
    void directionalOffset(int time) 
    {
        //where is the player currently facing
        if (Input.GetKey(KeyCode.W)) 
        {
            attackDirection.position += new Vector3(0,1,0);
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            attackDirection.position += new Vector3(1,0,0);
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            attackDirection.position += new Vector3(0,-1,0);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            attackDirection.position += new Vector3(-1,0,0);
        }

        //reset attack area to match player position
        if (time == 1) 
        {
            attackDirection.position = transform.position;
            
        }
    }

    //Shows melee area in scene view
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackDirection.position, attackArea);
    }
}
