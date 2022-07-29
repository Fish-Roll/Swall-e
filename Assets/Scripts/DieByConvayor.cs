using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class DieByConvayor : MonoBehaviour
    {
        [SerializeField]
        private Checkpoint _checkpoint;
        [SerializeField]
        private GameObject _outScreen;
        [SerializeField]
        private AudioSource _deathSound;
        //private GameObject _player;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            _deathSound.Play();
            _outScreen.SetActive(true);
            //_player.GetComponent<Movement>().enabled = false;
            other.transform.position = _checkpoint.transform.position;
            other.transform.rotation = Quaternion.identity;

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //_player.GetComponent<Movement>().enabled = true;
                _outScreen.SetActive(false);
            }
        }
    }
}