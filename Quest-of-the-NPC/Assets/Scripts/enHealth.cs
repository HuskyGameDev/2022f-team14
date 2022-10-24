using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enHealth : MonoBehaviour
{
    [SerializeField] public int health;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health < 0) { Destroy(gameObject); }
    }

    public void takeDamage(int damage) 
    {
        health -= damage;
    }
}
