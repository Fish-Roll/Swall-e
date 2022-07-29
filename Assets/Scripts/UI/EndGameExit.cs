using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameExit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }
}
