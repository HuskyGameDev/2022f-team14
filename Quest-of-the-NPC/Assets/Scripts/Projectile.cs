using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20.0f;
    public Camera mainCamera; 
    public Vector2 widthThresold;
    public Vector2 heightThresold;
    Vector3 moveDirection;
    [SerializeField] public int slowRangedAttackDamage;

    public GameObject enemy;
    
    
    void Awake() {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    } 
    // Update is called once per frame
    void Update()
    {   
        Vector3 angle = new Vector3(0, 0, 1);
        transform.position += (transform.right) * Time.deltaTime * speed;
        Vector2 screenPosition = mainCamera.WorldToScreenPoint (transform.position);
    }

    private void OnCollisionEnter2D(Collision2D  collision) {
        if(collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<enHealth>().takeDamage(slowRangedAttackDamage);
        }
        if(collision.gameObject.tag != "projectile") { Destroy(gameObject); }
    }
}
