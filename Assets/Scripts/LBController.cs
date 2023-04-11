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
    private Rigidbody2D rb;
    private TrailRenderer tr;
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
    public float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int dashDir;
    private float backUpGScale;
    public float driftFade;
    public int canDash;
    public bool isFloating;
    public float floatDuration;


    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
        faceRight = true;
        jumpState = 0;
        isTouchingWall = false;
        win = false;
        death = 0;
        dashTime= startDashTime;
        dashDir=0;
        tr = GetComponent<TrailRenderer>();
        backUpGScale = 1.05f;
        canDash = 1;
        isFloating = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isTouchingGround == true){
            canDash = 1;
            isFloating = false;
            floatDuration = 150;
        }
        if (win == false && death < 1 && gC.isPaused == false){
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

            if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && isTouchingGround == true){
                rb.velocity = new Vector2(rb.velocity.x, 1 * jumpSpeed);
                isJumping = true;
                jumpTimeCounter = jumpTime;
            }
            if ((Input.GetKey("up") || Input.GetKey("w")) && isJumping == true){
                if (jumpTimeCounter > 0){
                    rb.velocity = new Vector2(rb.velocity.x, 1 * jumpSpeed);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else{
                    isJumping = false;
                }
            }
        //Dash code (only execute if day)
        if(gC.dayOrNight == 0){
            if(dashDir==0){
                if((Input.GetKeyDown("z") || Input.GetKeyDown("m")) && canDash == 1){
                     dashDir= (faceRight)?1: -1;
                     tr.emitting= true;
                     canDash--;
                }

            }
            else{
                if(dashTime<=0){
                    dashDir=0;
                    dashTime=startDashTime;
                    rb.velocity = Vector2.zero;
                    tr.emitting= false;
                }
                else{
                    dashTime-=Time.deltaTime;
                    rb.velocity = new Vector2(1*dashDir*dashSpeed, rb.velocity.y);
                }
            }
        }

        //hover code
        if(gC.dayOrNight==1){
            if((Input.GetKey("z") || Input.GetKey("m")) && isTouchingGround == false){
                if (floatDuration > 0){
                    rb.gravityScale = 0;
                    rb.velocity= new Vector2(rb.velocity.x, -driftFade);
                    isFloating = true;
                    floatDuration--;
                }
                else{
                    rb.gravityScale= backUpGScale;
                    isFloating = false;
                    floatDuration = 0; 
                }
            }
            if(Input.GetKeyUp("z") || Input.GetKeyUp("m")){
                rb.gravityScale= backUpGScale;
                isFloating = false;
            }

        }

            if(Input.GetKeyUp("up") || Input.GetKeyUp("w")){
                isJumping = false;
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
        if (other.gameObject.tag == "BottomBorder" || other.gameObject.tag == "Bullet"){
            playerDeath();
        }
    }

    public IEnumerator deathSequence(){
        this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        death = 1;
        yield return new WaitForSeconds(1f);
        death = 2;
    }

    public void playerDeath(){
        StartCoroutine(deathSequence());
    }
}
