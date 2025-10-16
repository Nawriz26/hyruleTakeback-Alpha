using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private PlayerHealth player;

    private void Update()
    {
        if (player && hpText)
        {
            hpText.text = $"HP: {player.CurrentHP}/{player.maxHP}";
        }

        if (gemText)
        {
            gemText.text = $"Gems: {Gem.Count}";
        }
        else
        {
            Debug.LogWarning("HUD: gemText reference is not assigned!");
        }

        if (scoreText && GameManager.Instance != null)
        {
            scoreText.text = $"Score: {GameManager.Instance.totalScore}";
        }

        if (timeText && GameManager.Instance != null)
        {
            timeText.text = $"Time: {GameManager.Instance.GetFormattedTime()}";
        }

        if (levelText && GameManager.Instance != null)
        {
            levelText.text = $"Level: {GameManager.Instance.currentLevel}";
        }
    }
}
