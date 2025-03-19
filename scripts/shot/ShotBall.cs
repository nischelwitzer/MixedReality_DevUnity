using UnityEngine;

// https://www.youtube.com/watch?v=bSYoRoIVvvo

public class ShotBall : MonoBehaviour
{
    [SerializeField] private GameObject myPrefabShot;
    [SerializeField] private Transform dirTransform;
    public float speed = 15.0f;

    public void FireAShot()
    {
        Vector3 shift = new Vector3(0.05f, 0.04f, 0.12f);    
        GameObject shot = Instantiate(myPrefabShot, dirTransform.position + shift, Quaternion.identity);
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        // rb.linearVelocity = dirTransform.forward * speed;
        rb.AddForce(dirTransform.forward * speed, ForceMode.Impulse);

        Debug.LogWarning("ShotBall: FireAShot: " + rb.linearVelocity);
    }
}
