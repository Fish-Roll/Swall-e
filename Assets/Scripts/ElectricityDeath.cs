using System.Collections;
using Assets.Scripts;
using UnityEngine;

public class ElectricityDeath : MonoBehaviour
{
    [SerializeField]
    private Checkpoint _checkpoint;
    [SerializeField]
    private GameObject _deathScreen;

    [SerializeField] private GameObject _electricity;
    [SerializeField] private float _cooldownElectricity;
    private float cooldown;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        if(_deathScreen != null)
            _deathScreen.SetActive(true);
        other.transform.position = _checkpoint.transform.position;
        other.transform.rotation = Quaternion.identity;
        // Time.timeScale = 0f;
    }
    void Update()
    {
        if(_deathScreen != null)
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Time.timeScale = 1f;
                _deathScreen.SetActive(false);
            }
    }

    private IEnumerator CooldownElectricity()
    {
        cooldown = 0;
        while (true)
        {
            cooldown += Time.deltaTime;
            
        }
    }
}
