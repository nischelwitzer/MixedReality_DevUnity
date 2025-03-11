using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using static OVRPlugin;

public class FingerDetector : MonoBehaviour
{
    // see also https://www.youtube.com/watch?v=Rs5C01sDF88

    public OVRHand hand; // Die OVRHand-Referenz muss im Unity-Editor gesetzt werden
    public OVRSkeleton skeleton; // OVRSkeleton, um auf Knochen-Daten zuzugreifen
    public GameObject myGO;

    public TextMeshPro handText;
    private OVRHand.TrackingConfidence _confidence;

    [SerializeField]
    [Tooltip("The finger transform.")]
    private Transform _pointTransform;
    private int _boneIndex = 0;

    private void Start()
    {
        InvokeRepeating("IncrementBoneID", 5.0f, 2.0f);
    }

    private void IncrementBoneID()
    {
        _boneIndex++;
        if (_boneIndex > 25)
            _boneIndex = 0;
    }

    private void FixedUpdate()
    {
        if (skeleton == null || !hand.IsTracked)
            return;

        Debug.Log("Right hand is tracked");
        CheckFingerPointer(hand);
    }

    void CheckFingerPointer(OVRHand hand)
    {
        _confidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        // Durchlaufe alle Knochen, um den Zeigefinger zu finden
        foreach (var bone in skeleton.Bones)
        {
            // Body_RightHandIndexTip kleiner Finger 
            // Hand_IndexTip 20 Ringfinger
            // OVRPlugin.BoneId.Hand_Middle2 Zeigfinger 10

            if (bone.Id == (OVRSkeleton.BoneId)_boneIndex) //  OVRSkeleton.BoneId.Hand_RingTip) //  Hand_IndexTip) 
            {
                Vector3 indexTipPosition = bone.Transform.position;
                Debug.Log("Zeigefingerspitze Position: " + indexTipPosition);
                handText.text = _boneIndex.ToString();
                myGO.transform.position = indexTipPosition;
            }
        }
    }
}
