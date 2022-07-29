using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool _gameIsPaused = false;
    [SerializeField]
    private GameObject _pauseMenuUI;
    [SerializeField]
    private GameObject _authorsMenu;
    [SerializeField]
    private GameObject _player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        _authorsMenu.SetActive(false);
        _pauseMenuUI.SetActive(false);
        _player.GetComponent<Movement>().enabled = true;
        _gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        var myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        _player.GetComponent<Movement>().enabled = false;
        _gameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void BackToMainMenu()
    {
        _gameIsPaused = false;
        _player.GetComponent<Movement>().enabled = true;
        //Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenuScene");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
