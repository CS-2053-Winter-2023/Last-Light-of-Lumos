using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

public GameObject day, dayFloor;
public GameObject night, nightFloor;
public GameObject winMessage, lightIcon, darkIcon;
public int dayOrNight = 0, i = 0, lightPoints, darkPoints, totalLight, totalDark;
public float currentTime;
public AudioSource shiftSound, levelMusic;
public LBController lb;
public TextMeshProUGUI timer, darkDisplay, lightDisplay;
public bool winState;

    // Start is called before the first frame update
    void Start()
    {
        day.SetActive(true);
        night.SetActive(false);
        dayFloor.SetActive(true);
        nightFloor.SetActive(false);
        shiftSound = GetComponent<AudioSource>();
        levelMusic = GetComponent<AudioSource>();
        levelMusic.Play();
        winMessage.SetActive(false);
        lightIcon.SetActive(false);
        darkIcon.SetActive(false);
        currentTime = 0f;
        darkPoints = 0;
        lightPoints = 0;
        darkDisplay.text = "";
        lightDisplay.text = "";
        winState = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && winState == false){
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
        winState = true;
        winMessage.SetActive(true);
        StartCoroutine(DisplayScore());
    }

    public IEnumerator DisplayScore()
    {
        yield return new WaitForSeconds(1.5f);
        lightDisplay.text = "Light Gems Collected: " + lightPoints + " / " + totalLight;
        lightIcon.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        darkDisplay.text = "Dark Gems Collected: " + darkPoints + " / " + totalDark;
        darkIcon.SetActive(true);
    }
}

