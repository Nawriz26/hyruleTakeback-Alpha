using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

/// <summary>
/// Controls a popup panel showing game controls and instructions.
/// Attach to the controls panel GameObject in your main menu.
/// </summary>
public class ControlsScreen : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private Button showButton;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        if (controlsPanel == null)
        {
            controlsPanel = gameObject;
        }

        if (showButton != null)
        {
            showButton.onClick.AddListener(ShowControls);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(HideControls);
        }

        HideControls();
    }

    private void OnDestroy()
    {
        if (showButton != null)
        {
            showButton.onClick.RemoveListener(ShowControls);
        }

        if (closeButton != null)
        {
            closeButton.onClick.RemoveListener(HideControls);
        }
    }

    public void ShowControls()
    {
        if (controlsPanel != null)
        {
            controlsPanel.SetActive(true);
        }
    }

    public void HideControls()
    {
        if (controlsPanel != null)
        {
            controlsPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (controlsPanel != null && controlsPanel.activeSelf && Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            HideControls();
        }
    }
}
