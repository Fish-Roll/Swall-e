﻿using System.Collections;
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

        [SerializeField] private AudioSource _deathSound;
        
        private GameObject _player;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (_tool != null)
            {
                if (_deathScreen == null)
                {
                    _player.transform.position = _checkpoint.transform.position;
                    _player.transform.rotation = Quaternion.identity;
                }
                _tool.SetActive(true);
            }
            else
            {
                StartCoroutine(Death());
            }
        }


        private IEnumerator Death()
        {
            _player.GetComponent<Movement>().enabled = false;
            _player.GetComponentInChildren<Animator>().SetTrigger("die");
            _deathSound.Play();
            yield return new WaitForSeconds(2.5f);

            _deathScreen?.SetActive(true);
            yield return null;
        }

        private void Update()
        {
            if (_deathScreen != null)
            {
                if (!_deathScreen.activeInHierarchy) return;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1f;
                    _deathScreen.SetActive(false);
                    _player.GetComponent<Movement>().enabled = true;
                    _player.transform.position = _checkpoint.transform.position;
                    _player.transform.rotation = Quaternion.identity;
                }
            }
        }
    }
}