using Assets.Scripts.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class AbilityDispenser : MonoBehaviour
    {
        [SerializeField]
        private KeyCode _keyCode;
        //[SerializeField]
        //private Button _button;
        public Button _button;

        [SerializeField]
        private Ability _ability;

        [SerializeField] private AudioSource _newBackmusic;
        [SerializeField] private AudioSource _oldBackmusic;
        [SerializeField] private AudioSource _getAbilitySound;
        private void Awake()
        {
            _ability.Key = _keyCode;
            //if (!_button)
            //{
            //    _ability.But = _button.GetComponent<Button>();
            //}
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