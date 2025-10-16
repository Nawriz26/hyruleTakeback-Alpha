using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            if (scoreText) scoreText.text = $"Gems Collected: {GameManager.Instance.totalScore}";
            if (timeText) timeText.text = $"Time: {GameManager.Instance.GetFormattedTime()}";
        }

        if (retryButton) retryButton.onClick.AddListener(OnRetry);
        if (mainMenuButton) mainMenuButton.onClick.AddListener(OnMainMenu);

        Time.timeScale = 1f;
    }

    private void OnRetry()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartNewGame();
        }
        SceneManager.LoadScene("Level01");
    }

    private void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
