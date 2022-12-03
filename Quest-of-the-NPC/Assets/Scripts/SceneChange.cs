using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Scene scene;
    public int killCount = 0;
    void Awake() {
        killCount = 0;
        scene = SceneManager.GetActiveScene();
    }
    
        
    void OnTriggerEnter2D(Collider2D col) {
        if(scene.name == "Forest" && col.tag == "Player") {
            if(killCount >= 3) {
                SceneManager.LoadScene("Backrooms");
            }
            
        }
    }
}
