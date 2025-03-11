using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerEventHandler : MonoBehaviour
{
    // Uses PlayerInput
    // from Input Actions

    public void OnThumpstick_Right(InputValue movementValue)
    {
        Vector2 direction = movementValue.Get<Vector2>();
        // transform.Translate(direction);
        // rb.AddForce(movement * ballSpeed, ForceMode.Force);
        this.transform.Rotate(direction.y, direction.x, 0);
        Debug.Log("##### ControllerEventHandler: OnThumpstick_Right " + direction);
    }

    public void OnHMD_Device(InputValue movementValue)
    {
        Vector3 direction = movementValue.Get<Vector3>();
        Vector3 movement = new Vector3(direction.x, 0, direction.z);
        Debug.Log("##### ControllerEventHandler: OnHMD_Device " + direction);
    }

    public void OnButtonB_Right(InputValue value)
    {
        if (value.isPressed) 
            Debug.Log("##### ControllerEventHandler: OnButtonB_Right pressed " + value);
    }
}

