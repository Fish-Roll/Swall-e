using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer _videoPlayer;

    void Update()
    {
        if (_videoPlayer.isPaused || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("saber3 copy");
        }
    }

}
