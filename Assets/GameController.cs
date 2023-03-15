using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

public GameObject day;
public GameObject night;
public int dayOrNight;

    // Start is called before the first frame update
    void Start()
    {
        int dayOrNight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            Debug.Log(dayOrNight);
            if (dayOrNight == 0){
                day.SetActive(false);
                night.SetActive(true);
                dayOrNight = 1;
            }
            else{
                day.SetActive(true);
                night.SetActive(false);
                dayOrNight = 0;
            }
        }
    }
}

