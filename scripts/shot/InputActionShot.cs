using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionShot : MonoBehaviour
{
    [Tooltip("GameObject to activate after EnterEvent")]
    public UnityEvent toExecuteFired;

    public void OnRightTrigger(InputValue triggerValue)
    {
        float trigger = triggerValue.Get<float>();

        if (toExecuteFired != null)
        {
            if (trigger >= 1.0f)
                toExecuteFired.Invoke();
        }

        Debug.Log("##### ControllerEventHandler: OnRightTrigger: " + trigger);
    }

    public void OnButtonB_Right(InputValue value)
    {
        if (value.isPressed)
            Debug.Log("##### ControllerEventHandler: OnButtonB_Right pressed " + value);
    }
}
