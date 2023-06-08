using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts
{
    public class AbilityHandler : MonoBehaviour, IAbilityHandler
    {
        [SerializeField]
        private List<Ability> _abilities;
        public IReadOnlyCollection<Ability> GetAbilities => _abilities.ToList();

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