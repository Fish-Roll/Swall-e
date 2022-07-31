using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CheckpintPosition : MonoBehaviour
    {
        public Checkpoint _checkpoint;



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CheckpointTrigger._checkpoint = _checkpoint;
                //«аписываем позицию точки сохранени€ в переменную
            }
        }
    }
}
