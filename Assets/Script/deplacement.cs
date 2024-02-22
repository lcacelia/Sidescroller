using UnityEngine;

public class Deplacement : MonoBehaviour
{
    // variable pour le deplacement 
    //vitesse de deplacement
    public float moveSpeed;
    public float jumpForce;


    // permet d savoir si le Payer saute
    public bool isJumping;

    // permet d savoir si le Payer est sur le sol
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    // permet de faire déplacer le perso en aoutant un force
    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        //Calcule du mouvement 
        // Time.deltaTime <-- aussi longtemps qu'on appuis dans la vrai vie sur la touche le perso avancera 
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }


        // Application du mouvement
        MovePlayer(horizontalMovement);

    }

    void MovePlayer(float _horizontalMovement) //ajout "" car c'est un parmettre et permet de pas se tromper avec horizontalMovement
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);//"_horizontalMovement" <-- direction dans la quelle on va se deplacer et "rb.velocity.y" <-- on a deffinit un new Vector2 il faut l associer une valeur a y
        // "SmoothDamp" <-- deplacement "lisse"
        // ".05f" temp que le perso fera l'action ici o,5 sec
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);


        // rajout condition pour que le perso saute
        if (isJumping == true)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0f, jumpForce));

        }
    }

}