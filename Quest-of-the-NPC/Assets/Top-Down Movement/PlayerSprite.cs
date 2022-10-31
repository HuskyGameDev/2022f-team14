using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprite : MonoBehaviour
{
    void Update()
    {
        FaceMouse();
    }

    private void FaceMouse()
    {
        Vector3 input = Input.mousePosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(input);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
}
