using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBAudioManager : MonoBehaviour
{
    public AudioSource src;
    public AudioClip lbJump, lbDeath, lightPickup, darkPickup;
    public LBController lb;
    public GameController gc;
    public int oldPointsL, oldPointsD;
    private bool playedDeathSound;

    void Start(){
        playedDeathSound = false;
        oldPointsL = 0;
        oldPointsD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && lb.jumpState == 0){
            src.clip = lbJump;
            src.Play();
        }

        if (lb.death == 1 && playedDeathSound == false){
            src.clip = lbDeath;
            src.Play();
            playedDeathSound = true;
        }
        
        if (oldPointsL < gc.lightPoints){
            src.clip = lightPickup;
            src.Play();
            oldPointsL = gc.lightPoints;
        }

        if (oldPointsD < gc.darkPoints){
            src.clip = darkPickup;
            src.Play();
            oldPointsD = gc.darkPoints;
        }

    }
}
