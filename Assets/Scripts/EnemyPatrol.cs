using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour, IDamageable
{
    public float speed = 2f;
    public Transform leftPoint, rightPoint;
    public int maxHP = 3;
    
    [Header("Audio")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;

    Rigidbody2D rb;
    SpriteRenderer sr;
    int hp;
    bool movingRight = true;

    void Awake() 
    { 
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
        hp = maxHP; 
    }

    void Update()
    {
        // If patrol points aren�t set, don�t move (avoids null refs)
        if (!leftPoint || !rightPoint) { rb.linearVelocity = Vector2.zero; return; }

        float targetX = movingRight ? rightPoint.position.x : leftPoint.position.x;
        float dir = Mathf.Sign(targetX - transform.position.x);
        rb.linearVelocity = new Vector2(dir * speed, 0f);

        if (movingRight && transform.position.x >= rightPoint.position.x) movingRight = false;
        else if (!movingRight && transform.position.x <= leftPoint.position.x) movingRight = true;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        
        // Play hit sound
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
        
        // Visual feedback (already exists)
        if (sr != null)
        {
            StartCoroutine(HitFlash());
        }
        
        if (hp <= 0)
        {
            // Play death sound
            if (deathSound != null)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }
            
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(50);
            }
            Destroy(gameObject);
        }
    }
    
    private IEnumerator HitFlash()
    {
        Color original = sr.color;
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = original;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
            col.collider.GetComponent<PlayerHealth>()?.TakeDamage(1);
    }

    // Helps you see patrol limits in Scene view
    void OnDrawGizmosSelected()
    {
        if (leftPoint && rightPoint)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(leftPoint.position, rightPoint.position);
            Gizmos.DrawSphere(leftPoint.position, 0.05f);
            Gizmos.DrawSphere(rightPoint.position, 0.05f);
        }
    }
}
