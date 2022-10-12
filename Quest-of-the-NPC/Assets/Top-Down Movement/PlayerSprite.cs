using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;
    [SerializeField] private Sprite side;
    
    private PlayerInputActions playerInput;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        playerInput = new PlayerInputActions();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            _spriteRenderer.sprite = up;
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            _spriteRenderer.sprite = down;
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            _spriteRenderer.sprite = side;
            _spriteRenderer.flipX = false;
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            _spriteRenderer.sprite = side;
            _spriteRenderer.flipX = true;
        }
    }
}
