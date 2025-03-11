using UnityEngine;

public class DMTEventHelpers : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("##### DMTEventHelpers: Start");
    }

    // Update is called once per frame
    public void HelperSize(float newSize)
    {
        Vector3 newScaling = this.transform.localScale * newSize;
        this.transform.localScale = newScaling;
    }
}
