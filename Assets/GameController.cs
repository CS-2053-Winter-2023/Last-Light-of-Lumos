using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

public GameObject day;
public GameObject night;
public GameObject lightB;
public GameObject darkB;
public int dayOrNight;

    // Start is called before the first frame update
    void Start()
    {
        int dayOrNight = 0;
        night.SetActive(false);
        darkB.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            Debug.Log(dayOrNight);
            if (dayOrNight == 0){
                day.SetActive(false);
                night.SetActive(true);
                lightB.GetComponent<SpriteRenderer>().enabled = false;
                darkB.GetComponent<SpriteRenderer>().enabled = true;
                dayOrNight = 1;
            }
            else{
                day.SetActive(true);
                night.SetActive(false);
                lightB.GetComponent<SpriteRenderer>().enabled = true;
                darkB.GetComponent<SpriteRenderer>().enabled = false;
                dayOrNight = 0;
            }
        }
    }
}

