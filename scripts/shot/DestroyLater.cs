using UnityEngine;
using System.Collections;

public class DestroyLater : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 10.0f;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
