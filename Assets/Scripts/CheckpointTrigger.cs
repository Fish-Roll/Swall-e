using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class CheckpointTrigger : MonoBehaviour
    {
        [SerializeField]
        private Checkpoint _checkpoint;
        [SerializeField]
        private GameObject _deathScreen;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            for (int i = 0; i < 3; i++)
            {
                Time.timeScale = 0.5f;
                System.Threading.Thread.Sleep(500);
                if (i == 2)
                {
                    _deathScreen.SetActive(true);
                    other.transform.position = _checkpoint.transform.position;
                    other.transform.rotation = Quaternion.identity;
                }
            }
           
           // Time.timeScale = 0f;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1f;
                _deathScreen.SetActive(false);

            }
        }
     
    }
}