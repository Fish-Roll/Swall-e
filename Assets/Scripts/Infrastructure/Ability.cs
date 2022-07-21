using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public abstract class Ability : MonoBehaviour
    {
        public KeyCode Key { get; set; }

        public abstract void Activate(GameObject obj);
    }
}