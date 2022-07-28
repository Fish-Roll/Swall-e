using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEffect : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private float timeEffect;
    public float _currentTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine("Activate");
    }

    private IEnumerator Activate()
    {
        effect.SetActive(true);
        while (true)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= timeEffect)
            {
                effect.SetActive(false);
                StopCoroutine("Activate");
            }

            yield return null;
        }
    }
}
