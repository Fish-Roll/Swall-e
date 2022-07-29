using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpHintTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _doubleJumpHint;
    [SerializeField]
    private GameObject _ui;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Time.timeScale = 0f;
        _ui.SetActive(false);
        _doubleJumpHint.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            _doubleJumpHint.SetActive(false);
            _ui.SetActive(true);
        }   
    }
}
