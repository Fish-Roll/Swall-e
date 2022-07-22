using UnityEngine;

namespace Assets.Scripts
{
    public class CheckpointTrigger : MonoBehaviour
    {
        [SerializeField]
        private Checkpoint _checkpoint;
        [SerializeField]
        private GameObject _deathScreen;

        [SerializeField] 
        private GameObject _tool;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            if(_deathScreen != null)
                _deathScreen.SetActive(true);
            if(_tool != null)
                _tool.SetActive(true);
            other.transform.position = _checkpoint.transform.position;
            other.transform.rotation = Quaternion.identity;
            // Time.timeScale = 0f;
        }

        void Update()
        {
            if(_deathScreen != null)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1f;
                    _deathScreen.SetActive(false);
                }
        }
     
    }
}