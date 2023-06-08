using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHintTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _dashHint;
    [SerializeField]
    private GameObject _ui;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        //Time.timeScale = 1f;
        _ui.SetActive(false);
        _dashHint.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Time.timeScale = 1f;
            _dashHint.SetActive(false);
            _ui.SetActive(true);
        }
    }
}
