using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    public int killCount = 0;


    // GameManager object. We make it as an object to create a singleton to ensure that only one exists.
    public static GameManager gameManager { get; private set; }

    // Creates an EntityHealth object and gives it to the player.
    // We only have one player, and it always exists. Therefore it is in the GameManager
    public EntityHealth _playerHealth = new EntityHealth(100, 100, 0);
 
    void Awake()
    {
        // If a gameManager object already exists and another is created, get rid of it.
        // Otherwise, make the gameManager
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }

    }
   
}
