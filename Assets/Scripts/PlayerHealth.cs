using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    public int CurrentHP => hp;

    private int hp;
    private Vector3 lastCheckpoint;

    private void Start()
    {
        hp = maxHP;
        lastCheckpoint = transform.position;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Vector3 pos)
    {
        lastCheckpoint = pos;
    }

    private void Respawn()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.lives--;

            if (GameManager.Instance.lives <= 0)
            {
                GameManager.Instance.GameOver();
                return;
            }
        }

        hp = maxHP;
        var rb = GetComponent<Rigidbody2D>();
        if (rb) rb.linearVelocity = Vector2.zero;
        transform.position = lastCheckpoint;
    }
}
