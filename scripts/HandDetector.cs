using TMPro;
using UnityEngine;

public class HandDetector : MonoBehaviour
{
    // see also https://www.youtube.com/watch?v=Rs5C01sDF88

    public OVRHand myHand;
    public TextMeshPro handText; 
    private float _pinchStrength = 0.0f;
    // private bool _isPinching = false;
    private OVRHand.TrackingConfidence _confidence;

    private void FixedUpdate()
    {
        if (myHand.IsTracked)
        {
            Debug.Log("Right hand is tracked");
        }

        CheckHandPointer(myHand);  
    }

    void CheckHandPointer(OVRHand hand)
    {
        _pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        _confidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        handText.text = "Pinch Strength: " + _pinchStrength.ToString();
    }
}
