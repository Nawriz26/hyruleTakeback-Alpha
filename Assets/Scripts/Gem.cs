using UnityEngine;

public class Gem : MonoBehaviour
{
    public static int Count = 0;

    [SerializeField] private int pointValue = 100;
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Count++;
            Debug.Log($"Gem collected! Total gems: {Count}");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(pointValue);
            }

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
