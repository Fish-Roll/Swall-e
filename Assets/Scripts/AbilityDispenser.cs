﻿using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts
{
    public class AbilityDispenser : MonoBehaviour
    {
        [SerializeField]
        private KeyCode _keyCode;

        [SerializeField]
        private Ability _ability;

        [SerializeField] private AudioSource _newBackmusic;
        [SerializeField] private AudioSource _oldBackmusic;
        [SerializeField] private AudioSource _getAbilitySound;
        private void Awake()
        {
            _ability.Key = _keyCode;
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            if (_getAbilitySound != null)
                _getAbilitySound.Play();
            other.GetComponent<IAbilityHandler>()?.AddAbility(_ability);
            
            if (_newBackmusic != null)
            {
                _oldBackmusic.Stop();
                _newBackmusic.Play();
            }
            //}
        }
    }
}