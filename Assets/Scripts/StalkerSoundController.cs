using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerSoundController : MonoBehaviour
{
    public AudioSource src;
    public AudioClip attack, walk, stDeath, revive;
    public GameController gc;
    public LBController lb;
    public StalkerScript sc;

    private bool playedDeath, playedRevive, playedAttack;
    // Start is called before the first frame update
    void Start()
    {
        playedDeath = false;
        playedRevive = false;
        playedAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(lb.transform.position, sc.transform.position) <= 20){
            if (gc.dayOrNight == 1 && sc.attackState == 0){
                StartCoroutine(playWalkSound());
            }

            if (sc.attackState == 1 && playedAttack == false){
                src.clip = attack;
                src.Play();
                playedAttack = true;
            }

            if (gc.dayOrNight == 0  && playedDeath == false){
                src.clip = stDeath;
                src.Play();
                playedDeath = true;
                playedRevive = false;
            }
            else if (gc.dayOrNight == 1  && playedRevive == false){
                src.clip = stDeath;
                src.Play();
                playedRevive = true;
                playedDeath = false;
            }

        }
    }

    public IEnumerator playWalkSound(){
        src.clip = walk;
        src.Play();
        yield return new WaitForSeconds(4);
    }
}
