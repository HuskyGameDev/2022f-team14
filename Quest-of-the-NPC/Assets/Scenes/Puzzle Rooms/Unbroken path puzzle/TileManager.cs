using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<Tile> tiles;
    [SerializeField] private WinningTile winningTile;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform player_spawn;
    [SerializeField] private int resetSeconds;
    [SerializeField] private GameObject key;

    private PlayerController playerController;
    private Rigidbody2D playerRigidBody;

    private void ResetTiles()
    {
        StartCoroutine(WaitAndReset());
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        
        // Disable key
        key.SetActive(false);
        
        // Subscribe to all tile events...
        foreach (Tile tile in tiles)
        {
            tile.TileDoubleStepEvent += ResetTiles;
        }

        winningTile.WinningTileStepDownEvent += CheckWin;
        
        SetPlayerToSpawn();
    }

    private IEnumerator WaitAndReset()
    {
        // Disable player movement
        playerController.enabled = false;
        playerRigidBody.velocity = Vector2.zero;
        
        // Change stepped on tiles to be down and red -- indicates failure
        foreach (Tile tile in tiles)
        {
            if (tile.HasBeenSteppedOn)
            {
                tile.SetToFailed();
            }
        }
        
        // Wait briefly before reset
        yield return new WaitForSeconds(resetSeconds);
        
        // Set player to spawn and reenable player movement
        playerController.enabled = true;
        SetPlayerToSpawn();
        
        // Reset all tiles
        foreach (Tile tile in tiles)
        {
            tile.Reset();
        }
    }

    private void CheckWin()
    {
        foreach (Tile tile in tiles)
        {
            if (!tile.HasBeenSteppedOn)
            {
                StartCoroutine(WaitAndReset());
                return;
            }
        }
        
        // All tiles have been completed. Set all tiles to win and disable :)
        foreach (Tile tile in tiles)
        {
            tile.SetToSucceed();
        }
        
        // Enable the key!
        key.SetActive(true);
    }

    private void InitializeVariables()
    {
        playerController = player.GetComponent<PlayerController>();
        playerRigidBody = player.GetComponent<Rigidbody2D>();
    }

    private void SetPlayerToSpawn()
    {
        player.transform.position = player_spawn.transform.position;
    }
}
