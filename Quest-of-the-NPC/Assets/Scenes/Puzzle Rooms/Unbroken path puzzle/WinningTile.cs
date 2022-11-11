using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTile : MonoBehaviour
{
    [SerializeField] private Sprite tile_up;
    [SerializeField] private Sprite tile_down;
    
    private SpriteRenderer spriteRenderer;

    public delegate void WinningTileHandler();

    public event WinningTileHandler WinningTileStepDownEvent;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StepOnTile();
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        StepOffTile();
    }

    private void StepOnTile()
    {
        spriteRenderer.sprite = tile_down;
        WinningTileStepDownEvent?.Invoke();
    }

    private void StepOffTile()
    {
        spriteRenderer.sprite = tile_up;
    }
    
}
