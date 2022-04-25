using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [SerializeField] private Vector3 offset;
        [SerializeField, Range(0, 0.5f)] private float smoothTime;

        private Vector3 velocity = Vector3.zero;

        private void LateUpdate()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            transform.position = Vector3.SmoothDamp(
                transform.position, target.position + offset, ref velocity, smoothTime);
        }
    }
}