using TMPro;
using UnityEngine;

public class HMDRotation : MonoBehaviour
{

    // public Matrix4x4 headToWorld;
    public GameObject vrcam;
    public GameObject vrcamTarget;
    public TextMeshPro infoText;

    void LateUpdate()
    {
        infoText.text = "HMD Matrix: \n" 
            + vrcam.transform.localToWorldMatrix.ToString();
        infoText.text += "\n\nHMD Rotation: " 
            + vrcam.transform.rotation.eulerAngles.ToString();  

        vrcamTarget.transform.rotation = vrcam.transform.rotation;
    }
}
