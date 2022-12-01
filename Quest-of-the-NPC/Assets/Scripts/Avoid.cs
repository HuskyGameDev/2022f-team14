using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;

    public Projectile_E projectile;
    public Transform firePos;
    public float fireCoolDown = 1.0f;
    public float fire;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
    void FixedUpdate()
    {
        Vector2 direction = findExit();
        rb.velocity = direction * speed;

        Vector2 playerDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        transform.up = direction;

    }

    void Update() {
        if(Time.time > fire) {
             Vector3 rot = firePos.rotation.eulerAngles;
             rot = new Vector3(rot.x,rot.y,rot.z - 75);
             Quaternion dir = Quaternion.Euler(rot.x, rot.y, rot.z);

            Instantiate(projectile, firePos.position, dir);

            rot = new Vector3(rot.x,rot.y,rot.z-60);
            dir = Quaternion.Euler(rot.x, rot.y, rot.z);
            Instantiate(projectile, firePos.position, dir);

            fire = Time.time + fireCoolDown;
        }
        
    }
}
