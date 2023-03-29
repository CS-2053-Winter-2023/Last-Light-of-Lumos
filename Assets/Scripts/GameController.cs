using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

public GameObject day;
public GameObject dayFloor;
public GameObject night;
public GameObject nightFloor;
public GameObject winMessage;
public int dayOrNight = 0, i = 0;
public float currentTime;
public AudioSource shiftSound;
public LBController lb;
public TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        day.SetActive(true);
        night.SetActive(false);
        dayFloor.SetActive(true);
        nightFloor.SetActive(false);
        shiftSound = GetComponent<AudioSource>();
        winMessage.SetActive(false);
        currentTime = 0f;
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

        if (lb.win == true){
            WinCondition();
        }
        else{
            currentTime += Time.deltaTime;
            if (currentTime >= 59.5){
                currentTime = 0f;
                i++;
            }
            if (currentTime < 9.5){
                timer.text = "Time: " + i + ":0" + currentTime.ToString("#");
            }
            else{
                timer.text = "Time: " + i + ":" + currentTime.ToString("#");
            }
        }
    }

    void WinCondition()
    {
        winMessage.SetActive(true);
    }
}

