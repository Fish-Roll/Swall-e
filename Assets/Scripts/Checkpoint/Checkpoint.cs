using UnityEngine;

namespace Assets.Scripts
{
    public class Checkpoint : MonoBehaviour
    {
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, 0.1f);
        }

#endif
    }
}