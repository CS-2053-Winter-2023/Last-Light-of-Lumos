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
public GameObject lightIcon, darkIcon, gameScreen, nextButton, resumeButton, menuButton, controls;
public int dayOrNight = 0, i = 0, lightPoints, darkPoints, totalLight, totalDark;
public float currentTime;
public AudioSource shiftSound, levelMusic;
public LBController lb;
public TextMeshProUGUI timer, darkDisplay, lightDisplay, message;
public bool winState, isPaused, addedScore;
private static int totalPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        day.SetActive(true);
        night.SetActive(false);
        dayFloor.SetActive(true);
        nightFloor.SetActive(false);
        gameScreen.SetActive(false);
        nextButton.SetActive(false);
        shiftSound = GetComponent<AudioSource>();
        levelMusic = GetComponent<AudioSource>();
        levelMusic.Play();
        lightIcon.SetActive(false);
        darkIcon.SetActive(false);
        currentTime = 0f;
        darkPoints = 0;
        lightPoints = 0;
        darkDisplay.text = "";
        lightDisplay.text = "";
        message.text = "";
        winState = false;
        isPaused = false;
        addedScore = false;
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        controls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && winState == false && isPaused == false){
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

        if (lb.death == 2){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && winState == false){
            isPaused = true;
            gameScreen.SetActive(true);
            message.text = "Paused";
            resumeButton.SetActive(true);
            menuButton.SetActive(true);
            Time.timeScale = 0f;
            controls.SetActive(true);
        }
    }

    void WinCondition()
    {
        gameScreen.SetActive(true);
        winState = true;
        message.text = "Temple Found";
        Debug.Log(totalPoints);
        StartCoroutine(DisplayScore());
    }

    public void resumeGame(){
        isPaused = false;
        gameScreen.SetActive(false);
        message.text = "";            
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        Time.timeScale = 1f;
        controls.SetActive(false);
    }

    public void backToMenu(){
        totalPoints = 0;
        SceneManager.LoadScene("Menu");
    }

    public void levelOnetoTwo(){
        SceneManager.LoadScene("LLOLStage2");
    }

    public void levelTwotoThree(){
        SceneManager.LoadScene("LLOLStage3");
    }

    public void levelThreetoFour(){
        SceneManager.LoadScene("LLOLStage4");
    }

    public void levelFourtoFive(){
        SceneManager.LoadScene("LLOLStage5");
    }

    public IEnumerator DisplayScore()
    {
        yield return new WaitForSeconds(1.5f);
        lightDisplay.text = "Light Gems Collected: " + lightPoints + " / " + totalLight;
        lightIcon.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        darkDisplay.text = "Dark Gems Collected: " + darkPoints + " / " + totalDark;
        darkIcon.SetActive(true);
        nextButton.SetActive(true);
        if (addedScore == false){
            totalPoints += lightPoints;
            totalPoints += darkPoints;
            addedScore = true;
        }
    }
}

