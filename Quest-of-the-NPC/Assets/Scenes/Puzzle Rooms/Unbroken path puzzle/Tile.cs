using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite tile_up;
    [SerializeField] private Sprite tile_down;
    [SerializeField] private Color completed_color;
    [SerializeField] private Color failed_color;
    [SerializeField] private Color win_color;
    
    public bool HasBeenSteppedOn = false;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    public delegate void TileDoubleStepHandler();

    public event TileDoubleStepHandler TileDoubleStepEvent;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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
        // Check if tile has already been stepped on
        if (HasBeenSteppedOn)
        {
            TileDoubleStepEvent?.Invoke();
        }
        else
        {
            spriteRenderer.color = completed_color;
            HasBeenSteppedOn = true;
        }
    }

    private void StepOffTile()
    {
        spriteRenderer.sprite = tile_up;
    }

    public void SetToFailed()
    {
        spriteRenderer.sprite = tile_down;
        spriteRenderer.color = failed_color;
    }

    public void SetToSucceed()
    {
        spriteRenderer.sprite = tile_down;
        spriteRenderer.color = win_color;
        boxCollider.enabled = false;
    }

    public void Reset()
    {
        spriteRenderer.sprite = tile_up;
        spriteRenderer.color = Color.white;
        HasBeenSteppedOn = false;
        boxCollider.enabled = true;
    }
}
