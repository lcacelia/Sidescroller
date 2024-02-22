using UnityEngine;
using UnityEngine.UI;

public class Deplacement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float horizontal;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;

    public Sprite jumpSprite; // Ajout d'une variable pour le sprite de saut
    private Sprite originalSprite; // Variable pour stocker le sprite original du joueur

    [SerializeField] public Text lait_counter;
    private int lait = 0;

    private void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite; // Stocke le sprite original du joueur au démarrage
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (isJumping) // Si le joueur saute, change le sprite en sprite de saut
        {
            GetComponent<SpriteRenderer>().sprite = jumpSprite;
        }
        else // Sinon, utilise le sprite original
        {
            GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(new Vector2(0f, jumpForce));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            lait += 1;
            lait_counter.text = "" + lait;
            Destroy(other.gameObject);
        }
    }
}
