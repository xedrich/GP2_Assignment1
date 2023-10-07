using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Remove the gameManager field from here, it will be accessed via GameManager.Instance

    public void StartGame()
    {
        // Access GameManager.Instance directly to reset the score and load the first level.
        GameManager.Instance.ResetScore();
        GameManager.Instance.LoadNextLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        // Access GameManager.Instance directly to reset the score and load the second level.
        GameManager.Instance.ResetScore();
        GameManager.Instance.LoadNextLevel(2);
    }
}
