using UnityEngine;

// https://www.youtube.com/watch?v=bSYoRoIVvvo

public class ShotBall : MonoBehaviour
{
    [SerializeField] private GameObject myPrefabShot;
    [SerializeField] private Transform dirTransform;
    [SerializeField] private Vector3 shiftTransfrom = new Vector3(0.05f, 0.04f, 0.12f);
    public float speed = 15.0f;

    public void FireAShot()
    {   
        GameObject shot = Instantiate(myPrefabShot, dirTransform.position + shiftTransfrom, Quaternion.identity);
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        // rb.linearVelocity = dirTransform.forward * speed;
        rb.AddForce(dirTransform.forward * speed, ForceMode.Impulse);

        Debug.LogWarning("ShotBall: FireAShot: " + rb.linearVelocity);
    }
}
