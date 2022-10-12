using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb; 

    // Determine direction of player in contrast to enemy, and move away
    Vector2 findExit() 
    {
        int left = 1;
        int down = 1;
        //is player to the left or right?
        if (player.position.x > transform.position.x)
        {
            left = -1;
        }
        //is player up or down?
        if (player.position.y > transform.position.y) 
        {
            down = -1;
        }

        return new Vector2(left, down); 
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        Vector2 direction = findExit();
        rb.velocity = direction * speed;

    }
}
