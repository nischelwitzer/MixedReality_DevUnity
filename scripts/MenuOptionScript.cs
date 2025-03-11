using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Serialization;
/*
 * MenuOptionScript.cs 
 * Version 1.3
 * 
 * author: Ettl Jörg, Brandner Vega, Kabosch Lena, Zhou Erjiao
 * last changed: 1.06.2024
 * 
 * description:
 * Handles collision events to trigger a timer and load a new scene or start a GameObject
 * 
 */

[RequireComponent(typeof(Image))]
public class MenuOptionScript : MonoBehaviour
{
    [Tooltip("Image that will be filled over time")]
    public Image workingImage;

    [Tooltip("Duration for the timer in seconds")]
    public float duration;

    private Coroutine timerCoroutine;

    [Tooltip("GameObject to activate after the timer ends (optional)")]
    public UnityEvent toExecute;

    private void Start()
    {
        if (workingImage == null)
        {
            workingImage = GetComponent<Image>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name} collided with {other.name}");

        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        timerCoroutine = StartCoroutine(TimerCoroutine(duration));
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{gameObject.name} ended collision with {other.name}");

        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
            if (workingImage != null)
            {
                workingImage.fillAmount = 1.0f; // Reset fill amount
            }
        }
    }

    private IEnumerator TimerCoroutine(float timeout)
    {
        float time = 0;

        while (time < timeout)
        {
            time += Time.deltaTime;
            if (workingImage != null)
            {
                workingImage.fillAmount = 1 - (time / timeout);
            }
            yield return null; // Wait until next frame
        }

        // Code to execute after timeout
        if (toExecute != null)
        {
            toExecute.Invoke();
        }
    }

    private void ActivateGameObject()
    {
        toExecute.Invoke(); // Activate the specified GameObject after timeout
    }

}
