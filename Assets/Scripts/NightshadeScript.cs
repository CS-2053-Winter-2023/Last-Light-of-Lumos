using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightshadeScript : MonoBehaviour
{
    private Animator anim;
    public AudioSource attack;
    public LBController lb;
    public int attackState;
    public float waitTime1, waitTime2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attack = GetComponent<AudioSource>();
        attackState = 0;
    }

    void Update()
    {
        anim.SetInteger("attackState", attackState);
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player"){
            attack.Play();
            StartCoroutine(attackSequence());
        }
    }

    public IEnumerator attackSequence(){
        attackState = 1;
        yield return new WaitForSeconds(waitTime1);
        lb.deathNotify();
        attackState = 2;
        yield return new WaitForSeconds(waitTime2);
        attackState = 0;
    }
}
