using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

public GameObject day;
public GameObject dayFloor;
public GameObject night;
public GameObject nightFloor;
public int dayOrNight = 0;
public AudioSource shiftSound;

    // Start is called before the first frame update
    void Start()
    {
        day.SetActive(true);
        night.SetActive(false);
        dayFloor.SetActive(true);
        nightFloor.SetActive(false);
        shiftSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            shiftSound.Play();
            if (dayOrNight == 0){
                day.SetActive(false);
                night.SetActive(true);
                dayFloor.SetActive(false);
                nightFloor.SetActive(true);
                dayOrNight = 1;
            }
            else{
                day.SetActive(true);
                night.SetActive(false);
                dayFloor.SetActive(true);
                nightFloor.SetActive(false);
                dayOrNight = 0;
            }
        }
    }
}

