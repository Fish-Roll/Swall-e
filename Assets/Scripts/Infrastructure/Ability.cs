using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure
{
    public abstract class Ability : MonoBehaviour
    {
        public KeyCode Key { get; set; }
        public Button But { get; set; }

        public abstract void Activate(GameObject obj);
    }
}