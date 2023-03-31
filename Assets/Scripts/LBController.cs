using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LBController : MonoBehaviour
{
    private Animator anim;
    public float direction;
    public float speed = 9.0f;
    public float jumpSpeed = 11.0f;
    public float peak;
    private Rigidbody2D rb;
    public bool faceRight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public bool isTouchingWall;
    public int jumpState;
    public GameController gC;
    public bool shifted, win;
    public int death;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
        peak = transform.position.y + 4;
        faceRight = true;
        jumpState = 0;
        isTouchingWall = false;
        win = false;
        death = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (win == false){
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

            if (isTouchingGround){
                jumpState = 0;
            }
            if (!(isTouchingGround)){
                if (rb.velocity.y > 0){
                    jumpState = 1;
                }
                else if (rb.velocity.y < 0){
                    jumpState = -1;
                }
                else{
                    jumpState = 2;
                }
            }

            if (gC.day.activeInHierarchy == true){
            shifted = true;
            }
            else{
                shifted = false;
            }
        }
        else{
            rb.velocity = new Vector2(0f,0f);
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("OnGround", isTouchingGround);
        anim.SetInteger("IsDark",  gC.dayOrNight);            
        anim.SetInteger("jumpState", jumpState);
        anim.SetBool("shifted", shifted);

    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        faceRight = !faceRight;
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Border"){
            isTouchingWall = true;
        }
        if (other.gameObject.tag == "End"){
            win = true;
        }
        if (other.gameObject.tag == "DarkGem"){
            other.gameObject.SetActive(false);
            gC.darkPoints++;
        }
        if (other.gameObject.tag == "LightGem"){
            other.gameObject.SetActive(false);
            gC.lightPoints++;
        } 
        if (other.gameObject.tag == "BottomBorder"){
            StartCoroutine(deathSequence());
        }
    }

    public IEnumerator deathSequence(){
        death = 1;
        yield return new WaitForSeconds(1f);
        death = 2;
    }
}
