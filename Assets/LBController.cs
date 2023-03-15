using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBController : MonoBehaviour
{
    public Animator anim;
    public bool isMoving;
    public GameObject darkMode;
    public Animator darkAnim;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>(); 
       isMoving = false;
       darkAnim = darkMode.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right")){
            isMoving = true;
        }
        if (Input.GetKeyUp("right")){
            isMoving = false;
        }

        if (isMoving == true){
            anim.Play("LBRunRight");
            darkAnim.Play("DBRunRight");
        }
        else{
            anim.Play("LBIdle");
            darkAnim.Play("DBIdle");
        }
    }
}
