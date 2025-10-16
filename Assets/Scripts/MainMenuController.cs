using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        if (playButton) playButton.onClick.AddListener(OnPlayClicked);
        if (quitButton) quitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnPlayClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartNewGame();
        }
        SceneManager.LoadScene("Level01");
    }

    private void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
