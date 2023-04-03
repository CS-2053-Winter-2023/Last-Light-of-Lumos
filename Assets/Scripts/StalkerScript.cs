using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerScript : MonoBehaviour
{   
    public GameController gc;
    public LBController lb;
    private Rigidbody2D sb;
    public bool isFacingLeft;
    private Animator anim;
    public int attackState;
    public bool hasAttacked;
    public float waitTime1,waitTime2, speed;
    public AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sb = GetComponent<Rigidbody2D>();
        attackSound = GetComponent<AudioSource>();
        attackState= 0;
        isFacingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("attack", attackState);
        anim.SetInteger("day", gc.dayOrNight);
    }

    void FixedUpdate()
    {
        if (gc.dayOrNight == 1){
            if ((attackState == 0) && isFacingLeft == true){
                sb.velocity = new Vector2(-speed, 0);
            }
            else if ((attackState == 0) && isFacingLeft == false){
                sb.velocity = new Vector2(speed, 0);
            }
            if (attackState == 1){
                sb.velocity = new Vector2(0, 0);
            }
        }
        else{
            sb.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && gc.dayOrNight == 1){
            StartCoroutine(attackSequence());
        }
        if (other.gameObject.tag == "Edge"){
            Flip();
        }
    }

    public IEnumerator attackSequence(){
        attackState = 1;
        attackSound.Play();
        yield return new WaitForSeconds(waitTime1);
        lb.playerDeath();
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingLeft = !isFacingLeft;
    }

}
