using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBController : MonoBehaviour
{
    private Animator anim;
    public float direction;
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    private Rigidbody2D rb;
    public bool faceRight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public GameController gC;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
        faceRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f || direction < 0f){
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            if (direction > 0f && !(faceRight)){
                    Flip();
            }
            if (direction < 0f && (faceRight)){
                Flip();
            }
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown("up") && isTouchingGround == true){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("OnGround", isTouchingGround);
        anim.SetInteger("IsDark",  gC.dayOrNight);

    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        faceRight = !faceRight;
    }
}
