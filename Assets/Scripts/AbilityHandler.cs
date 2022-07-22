using System.Collections.Generic;
using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts
{
    public class AbilityHandler : MonoBehaviour, IAbilityHandler
    {
        [SerializeField]
        private List<Ability> _abilities;

        private void Update()
        {
            _abilities.ForEach(_ =>
            {
                if (Input.GetKeyDown(_.Key))
                {
                    _.Activate(gameObject);
                }
            });
        }

        public void AddAbility(Ability ability)
        {
            _abilities.Add(ability);
        }
    }
}