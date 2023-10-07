using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int nextSceneIndex = 3;

    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager = GameManager.Instance; // Assign the GameManager instance.
            gameManager.LoadNextLevel(nextSceneIndex); // Load the next scene using GameManager.
        }
    }
}
