using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function for Play button, triggers main scene.
    public void PlayGame()
    {
        SceneManager.LoadScene("testingSceneSprint2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
