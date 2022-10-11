using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ICheckpointTrigger: MonoBehaviour
    {
        protected abstract Checkpoint checkpoint { get; set; }
        protected abstract GameObject TriggerScreen { get; set; }
        protected abstract AudioSource TriggerSound { get; set; }
        protected abstract GameObject Player { get; set; }
        public bool MovePlayer(GameObject player, Checkpoint checkpoint)
        {
            try
            {
                player.transform.position = checkpoint.transform.position;
                player.transform.rotation = Quaternion.identity;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return false;
            }

            return true;
        }
    }
}