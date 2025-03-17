using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerEventHandler : MonoBehaviour
{
    // Uses PlayerInput
    // from Input Actions

    public Transform goRotateAbs;
    public Transform goRotateRel;

    public void OnThumpstick_Right(InputValue movementValue)
    {
        Vector2 direction = movementValue.Get<Vector2>();
        // transform.Translate(direction);
        // rb.AddForce(movement * ballSpeed, ForceMode.Force);
        this.transform.Rotate(direction.y, direction.x, 0);

        goRotateAbs.transform.rotation = Quaternion.Euler(direction.y * Mathf.PI * 180/6, 0, -1 *  direction.x * Mathf.PI * 180/6);
        goRotateRel.transform.Rotate(direction.y, 0, -1 * direction.x);

        Debug.Log("##### ControllerEventHandler: OnThumpstick_Right " + direction);
    }

    public void OnButtonB_Right(InputValue value)
    {
        if (value.isPressed) 
            Debug.Log("##### ControllerEventHandler: OnButtonB_Right pressed " + value);
    }
}

