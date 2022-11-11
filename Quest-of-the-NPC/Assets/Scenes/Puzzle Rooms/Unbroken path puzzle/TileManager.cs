using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<Tile> tiles;
    [SerializeField] private Transform player;
    [SerializeField] private Transform player_spawn;

    private void ResetTiles()
    {
        SetPlayerToSpawn();
        foreach (Tile tile in tiles)
        {
            tile.Reset();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to all tile events...
        foreach (Tile tile in tiles)
        {
            tile.TileDoubleStepEvent += ResetTiles;
        }
        SetPlayerToSpawn();
    }

    private void SetPlayerToSpawn()
    {
        player.transform.position = player_spawn.transform.position;
    }
}
