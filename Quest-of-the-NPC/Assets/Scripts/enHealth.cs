using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enHealth : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public SceneChange SC;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health < 0) { 
            if(SC != null ) {SC.killCount++; } //when enemy is killed, updated killCount in Scene Change
            Destroy(gameObject); 
        }
    }

    public void takeDamage(int damage) 
    {
        health -= damage;
    }
}
