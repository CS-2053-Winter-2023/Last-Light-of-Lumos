using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBController : MonoBehaviour
{
    public Animator anim;
    public bool isMoving;
    public GameObject darkMode;
    public Animator darkAnim;
    public Vector3 velocity;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        isMoving = false;
        darkAnim = darkMode.GetComponent<Animator>();
        velocity = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right")){
            isMoving = true;
            velocity = new Vector3(2f, 0f, 0f);
        }
        if (Input.GetKeyUp("right")){
            isMoving = false;
            velocity = new Vector3(0f,0f,0f);
        }
        transform.position = transform.position + velocity * Time.deltaTime * speed;
        darkMode.transform.position = transform.position + velocity * Time.deltaTime * speed;

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
