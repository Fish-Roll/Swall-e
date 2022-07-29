using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(EndGameLoad());
        
    }
    private IEnumerator EndGameLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EndGameScene");
    }
}
