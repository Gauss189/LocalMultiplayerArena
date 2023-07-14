using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb { get; private set; }

    private Vector2 direction = Vector2.down;

    [Header("Controller")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private KeyCode inputUp = KeyCode.W;
    [SerializeField] private KeyCode inputDown = KeyCode.S;
    [SerializeField] private KeyCode inputLeft = KeyCode.A;
    [SerializeField] private KeyCode inputRight = KeyCode.D;
    [SerializeField] private KeyCode inputFire = KeyCode.Space;

    [Header("Shooting")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;

    [Header("AnimationSequnce")]
    [SerializeField] private AnimatedSpriteRenderer spriteRendererUp;
    [SerializeField] private AnimatedSpriteRenderer spriteRendererDown;
    [SerializeField] private AnimatedSpriteRenderer spriteRendererLeft;
    [SerializeField] private AnimatedSpriteRenderer spriteRendererRight;

    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        Vector2 currentDirection = direction;

        if (Input.GetKeyDown(inputFire) && currentDirection != Vector2.zero)
        {
            Vector3 instantiatePosition = GetInstantiationPosition(currentDirection);
            GameObject projectile = Instantiate(projectilePrefab, instantiatePosition, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = currentDirection * projectileSpeed;
        }
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }

    }

    private Vector3 GetInstantiationPosition(Vector2 direction)
    {
        Vector3 instantiatePosition = transform.position;

        if (direction == Vector2.up)
        {
            instantiatePosition += new Vector3(0, 1, 0);
        }
        else if (direction == Vector2.down)
        {
            instantiatePosition += new Vector3(0, -1, 0);
        }
        else if (direction == Vector2.left)
        {
            instantiatePosition += new Vector3(-1, 0, 0);
        }
        else if (direction == Vector2.right)
        {
            instantiatePosition += new Vector3(1, 0, 0);
        }

        return instantiatePosition;
    }

    private void FixedUpdate()
    {
        Vector2 position = playerRb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        playerRb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }
}
