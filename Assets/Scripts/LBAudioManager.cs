using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBAudioManager : MonoBehaviour
{
    public AudioSource src;
    public AudioClip lbJump, lbDeath;
    public LBController lb;
    public bool playedDeathSound;

    void Start(){
        playedDeathSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && lb.jumpState == 0){
            src.clip = lbJump;
            src.Play();
        }

        if (lb.death == 1 && playedDeathSound == false){
            src.clip = lbDeath;
            src.Play();
            playedDeathSound = true;
        }
    }
}
