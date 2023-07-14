using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    [SerializeField] private int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    private bool isKnockback;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && !isKnockback)
        {
            --currentHealth;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
        if (currentHealth <= 0)
        {
            Invoke(nameof(OnDeathSequence), 0.3f);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            Destroy(collision.gameObject);
        }
    }

    private void OnDeathSequence()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }
}
