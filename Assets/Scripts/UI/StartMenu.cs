using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Cutscene");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
