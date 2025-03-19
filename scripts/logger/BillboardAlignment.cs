using UnityEngine;

namespace LearnXR.Core.Utilities
{
    public class BillboardAlignment : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        private bool startedTracking;

        public void AttachTo(Transform targetTransform)
        {
            cameraTransform = targetTransform;
            startedTracking = true;
        }

        void Update()
        {
            if (!startedTracking) return;

            Vector3 directionToCamera = cameraTransform.position - transform.position;
            this.transform.rotation = Quaternion.LookRotation(directionToCamera);
            this.transform.rotation *= Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }
}