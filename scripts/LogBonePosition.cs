using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction.Input;

// https://developers.meta.com/horizon/documentation/unity/unity-isdk-get-bone-position

public class LogBonePosition : MonoBehaviour
{
    // [SerializeField]
    // private Hand hand;

    // private Pose currentPose;
    // private HandJointId handJointId = HandJointId.HandIndex3; // TO DO: Change this to your bone.

    void Update()
    {
        OVRPlugin.Skeleton skeleton;
        if (OVRPlugin.GetSkeleton(OVRPlugin.SkeletonType.HandRight, out skeleton))
            foreach (var bone in skeleton.Bones)
                if (bone.Id == OVRPlugin.BoneId.Hand_Index3)
                    Debug.Log("Bone: " + bone.Pose.Orientation.x);

        // Debug.Log("Bone: "+hand.GetJointPose(handJointId, out currentPose));
    }

}