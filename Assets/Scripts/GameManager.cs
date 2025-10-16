using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int totalScore;
    public int currentLevel = 1;
    public float totalTime;
    public int lives = 3;

    private bool isGameActive;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isGameActive)
        {
            totalTime += Time.deltaTime;
        }
    }

    public void StartNewGame()
    {
        totalScore = 0;
        currentLevel = 1;
        totalTime = 0f;
        lives = 3;
        Gem.Count = 0;
        isGameActive = true;
    }

    public void AddScore(int points)
    {
        totalScore += points;
    }

    public void CompleteLevel()
    {
        currentLevel++;
        isGameActive = false;
    }

    public void GameOver()
    {
        isGameActive = false;
        SceneManager.LoadScene("GameOver");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGameActive = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameActive = true;
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}
