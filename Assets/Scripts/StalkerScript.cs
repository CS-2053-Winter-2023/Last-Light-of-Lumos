using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerScript : MonoBehaviour
{   
    public GameController gc;
    private Animator anim;
    public int attackState;
    public float waitTime1;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        attackState= 0;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("attack", attackState);
        anim.SetInteger("day", gc.dayOrNight);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"&&gc.dayOrNight==1){
            StartCoroutine(attackSequence());
        }

    }

    public IEnumerator attackSequence(){
        attackState=1;

        yield return new WaitForSeconds(waitTime1);

        attackState=0;
    }

}
