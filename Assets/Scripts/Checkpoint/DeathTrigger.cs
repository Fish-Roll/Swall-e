using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class DeathTrigger:MonoBehaviour
    {
        [SerializeField] private GameObject triggerScreen;
        [SerializeField] private AudioSource triggerSound;
        private GameObject _player;
        private int deathTime = 0;
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

            if (deathTime == 0)
            {
                StartCoroutine(Death());
                deathTime = 1;
            }
        }

        private IEnumerator Death()
        {
            _player.GetComponent<Movement>().enabled = false;
            _player.GetComponentInChildren<Animator>().SetTrigger("die");
            _player.GetComponentInChildren<Animator>().SetBool("isDie", true);
            triggerSound.Play();
            yield return new WaitForSeconds(2.5f);
            triggerScreen?.SetActive(true);
            yield return null;
        }

        private void Update()
        {
            if (triggerScreen!= null && !triggerScreen.activeInHierarchy) return;
            MoveToCheckpoint.MovePlayer(_player);
            _player.GetComponentInChildren<Animator>().SetBool("isDie", false);
            if (Input.GetKeyDown(KeyCode.Space) && deathTime == 1)
            {
                triggerScreen.SetActive(false);
                _player.GetComponent<Movement>().enabled = true;
                deathTime = 0;
            }
        }
    }
}