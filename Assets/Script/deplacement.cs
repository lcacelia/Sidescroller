using UnityEngine;
using UnityEngine.UI;

public class deplacement : MonoBehaviour
{
    // variable pour le deplacement 
    //vitesse de deplacement
    public float moveSpeed;
    public float jumpForce;
    private float horizontal;
    private Animator anim;

    [SerializeField] public Text lait_counter;

    private int lait = 0;


    // permet d savoir si le Payer saute
    public bool isJumping;

    // permet d savoir si le Payer est sur le sol
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    // permet de faire déplacer le perso en aoutant un force
    public Rigidbody2D rb;
    public BoxCollider2D bc2d;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        //Calcule du mouvement 
        // Time.deltaTime <-- aussi longtemps qu'on appuis dans la vrai vie sur la touche le perso avancera 
        horizontal = Input.GetAxis("Horizontal");

        // saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            anim.SetTrigger("Jump");
        }


        // Application du mouvement
        MovePlayer();

       

    }

    void MovePlayer() //ajout "" car c'est un parmettre et permet de pas se tromper avec horizontalMovement
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);


        // rajout condition pour que le perso saute
        if (isJumping == true)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0f, jumpForce));

        }
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