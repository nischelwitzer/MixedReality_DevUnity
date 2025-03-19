
using UnityEngine;
using System.Collections;

public class Look2Camera : MonoBehaviour
{
    [SerializeField] private Transform referencePos;
    [SerializeField] private bool mirror;

    void Awake()
    {
        if (!referencePos)
            referencePos = Camera.main.transform;
    }

    void Update()
    {
        Transform transform = GetComponent<Transform>();
        this.transform.LookAt(referencePos.position);
        if (mirror)
            transform.Rotate(0, 180, 0);
    }
}