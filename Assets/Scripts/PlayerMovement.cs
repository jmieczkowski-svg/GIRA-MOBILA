using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Joystick joystick; // Tutaj podepniemy gotowy joystick z paczki!

    void Update()
    {
        Vector2 input = Vector2.zero;

        // 1. Odczyt z gotowego Joysticka na ekranie (myszka na PC + palec na telefonie)
        if (joystick != null)
        {
            input.x = joystick.Horizontal;
            input.y = joystick.Vertical;
        }

        // 2. Odczyt z klawiatury WASD (działa dodatkowo, gdy nie dotykamy joysticka)
        if (Keyboard.current != null && input == Vector2.zero)
        {
            if (Keyboard.current.aKey.isPressed)
                input.x -= 1;

            if (Keyboard.current.dKey.isPressed)
                input.x += 1;

            if (Keyboard.current.sKey.isPressed)
                input.y -= 1;

            if (Keyboard.current.wKey.isPressed)
                input.y += 1;

            input = input.normalized;
        }

        transform.position += (Vector3)(input * moveSpeed * Time.deltaTime);
    }
}