using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int YellowOrbCounter = 0;

    // Singleton instance
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        Debug.Log("GameManager Awake");

        // Ensure that only one GameManager instance exists.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        // Load the score when the game starts.
        LoadScore();
    }







    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadScore(); // Load the score when a scene is loaded.
        UpdateScoreText();
    }

    private void Start()
    {
        // Load the score when the game starts.
        LoadScore();
        UpdateScoreText();
    }

    public void CollectYellowOrb()
    {
        YellowOrbCounter += 50;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return YellowOrbCounter;
    }


    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + YellowOrbCounter.ToString();
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", YellowOrbCounter);
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            YellowOrbCounter = PlayerPrefs.GetInt("Score");
        }
    }

    public void ResetScore()
    {
        YellowOrbCounter = 0;
        UpdateScoreText();
        SaveScore(); // Save the score when it's reset.
    }

    public void LoadNextLevel(int levelIndex)
    {
        SaveScore(); // Save the score before loading the next level.
        SceneManager.LoadScene(levelIndex);
    }
}
