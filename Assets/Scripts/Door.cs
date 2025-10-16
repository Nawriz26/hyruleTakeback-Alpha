using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private float fadeTo = 0.25f;
    [SerializeField] private Color openColor = Color.green;
    [SerializeField] private bool changeColorWhenOpen = true;
    
    [Header("UI Feedback")]
    [SerializeField] private string lockedMessage = "Door Locked - Defeat the Boss!";
    [SerializeField] private float messageDisplayTime = 2f;
    
    private bool isOpen = false;
    
    public void Open()
    {
        if (isOpen) return;
        
        isOpen = true;
        
        var col = GetComponent<Collider2D>();
        if (col) col.enabled = false;

        var sr = GetComponent<SpriteRenderer>();
        if (sr)
        {
            if (changeColorWhenOpen)
            {
                sr.color = new Color(openColor.r, openColor.g, openColor.b, fadeTo);
            }
            else
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, fadeTo);
            }
        }
        
        Debug.Log("Door opened!");
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isOpen && collision.collider.CompareTag("Player"))
        {
            Debug.Log(lockedMessage);
        }
    }
}
