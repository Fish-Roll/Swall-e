using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts.Infrastructure
{
    public abstract class AbilityDispenser : MonoBehaviour
    {
        [SerializeField]
        private Ability _ability;

        protected void OnTriggerEnter(Collider other)
        {
            other.GetComponent<IAbilityHandler>()?.AddAbility(_ability);
        }
    }
}