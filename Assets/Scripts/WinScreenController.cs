using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private string nextLevelScene;
    [SerializeField] private AudioClip victory;
     private AudioSource audioSource;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            if (scoreText) scoreText.text = $"Score: {GameManager.Instance.totalScore}";
            if (timeText) timeText.text = $"Time: {GameManager.Instance.GetFormattedTime()}";
            if (gemsText) gemsText.text = $"Gems Collected: {Gem.Count}";
        }

        if (continueButton)
        {
            continueButton.onClick.AddListener(OnContinue);
            if (string.IsNullOrEmpty(nextLevelScene) || GameManager.Instance.currentLevel > 3)
            {
                continueButton.gameObject.SetActive(false);
            }
        }

        if (mainMenuButton) mainMenuButton.onClick.AddListener(OnMainMenu);
  
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null ) 
           audioSource = gameObject.AddComponent<AudioSource>();

        if (victory != null )
            audioSource.PlayOneShot(victory);
    }

    private void OnContinue()
    {
        if (!string.IsNullOrEmpty(nextLevelScene))
        {
            SceneManager.LoadScene(nextLevelScene);
        }
    }

    private void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
