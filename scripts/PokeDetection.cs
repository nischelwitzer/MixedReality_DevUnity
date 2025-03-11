using UnityEngine;

public class PokeDetection : MonoBehaviour
{
    public OVRHand myHand;

    void Update()
    {
        if (myHand.IsPointerPoseValid && myHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Debug.Log("Poke gesture detected with index finger!");
        }
    }
}

