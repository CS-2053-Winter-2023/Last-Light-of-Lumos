using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{   
    Vector3 velocity;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(velocity!=null){
            transform.Translate(velocity*Time.deltaTime);  
        }

        var dist= transform.position.z- Camera.main.transform.position.z;
        var topBorder= Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, dist)).y;
        var bottomBorder= Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, dist)).y;

        if(transform.position.y>topBorder || transform.position.y<bottomBorder){
            Destroy(gameObject);
        }
    }

    public void InitPosition(Vector3 p, Vector3 v){

        transform.position = p;
        velocity = v * 2/3;
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag != "DarkGem" || other.tag != "DarkGem"){
            Destroy(gameObject);
        }
    }
}