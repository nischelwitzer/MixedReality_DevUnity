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
        this.transform.Rotate(direction.y, direction.x, 0);

        Vector3 absRotation = new Vector3(1.0f * direction.y , 0, -1.0f * direction.x) * Mathf.PI * 180.0f / 6.0f;
        goRotateAbs.transform.rotation = Quaternion.Euler(absRotation);
        goRotateRel.transform.Rotate(direction.y, 0, -1.0f * direction.x);

        Debug.Log("##### ControllerEventHandler: OnThumpstick_Right Abs: " + absRotation);
        Debug.Log("##### ControllerEventHandler: OnThumpstick_Right Direction: " + direction);
    }

    public void OnButtonB_Right(InputValue value)
    {
        if (value.isPressed) 
            Debug.Log("##### ControllerEventHandler: OnButtonB_Right pressed " + value);
    }
}

