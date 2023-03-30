using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointController : MonoBehaviour
{

    private Animator anim;
    public int isWin;
    public GameController gC;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isWin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gC.winState == true){
            isWin = 1;
        }

        anim.SetInteger("Won", isWin);

    }
}
