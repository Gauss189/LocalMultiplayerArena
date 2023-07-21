using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int score;
    public int startScore;

    [SerializeField] private int maxHealth = 5;
    public int currentHealth;
    public HealthBarUI healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        SetScore(startScore);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
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
            SetScore(score);
        }
    }

    private void OnDeathSequence()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }

    private void SetScore(int score)
    {
        scoreText.SetText("Score: " + score);
    }
}
