using UnityEngine;

namespace Assets.Scripts
{
    public class CheckpointTrigger : MonoBehaviour
    {
        [SerializeField]
        private Checkpoint _checkpoint;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            other.transform.position = _checkpoint.transform.position;
            other.transform.rotation = Quaternion.identity;
        }

    }
}