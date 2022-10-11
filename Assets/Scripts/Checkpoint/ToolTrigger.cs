using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ToolTrigger:MonoBehaviour
    {
        [SerializeField] private GameObject tool;
        [SerializeField] private AudioSource triggerSound;
        private GameObject _player;


        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckpointTrigger(other);
        }

        private void CheckpointTrigger(Collider other)
        {
            if (!other.CompareTag("Player") || tool == null || triggerSound == null)
                return;
            triggerSound.Play();
            tool.SetActive(true);
        }
    }
}