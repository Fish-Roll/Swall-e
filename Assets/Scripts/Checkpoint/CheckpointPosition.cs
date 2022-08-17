using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts
{
    public class CheckpointPosition : MonoBehaviour
    {
        [SerializeField] private Checkpoint checkpoint;

        private void Awake()
        {
            MoveToCheckpoint.checkpoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Checkpoint>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
                MoveToCheckpoint.checkpoint = checkpoint;
        }
    }
}
