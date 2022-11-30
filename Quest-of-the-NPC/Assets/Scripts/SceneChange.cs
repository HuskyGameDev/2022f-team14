using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Scene scene;
    void Awake() {
        scene = SceneManager.GetActiveScene();
    }
    
        
    void OnTriggerEnter2D(Collider2D col) {
        if(scene.name == "Forest" && col.tag == "Player") {
            SceneManager.LoadScene("Test");
        }
    }
}
