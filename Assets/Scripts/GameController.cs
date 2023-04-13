using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

public GameObject day, dayFloor;
public GameObject night, nightFloor;
public GameObject lightIcon, darkIcon, gameScreen, nextButton, resumeButton, menuButton, controls;
public Image goodEndScreen, badEndScreen;
public int dayOrNight = 0, i = 0, lightPoints, darkPoints, totalLight, totalDark;
public float currentTime, t;
public AudioSource shiftSound;
public LBController lb;
public TextMeshProUGUI timer, darkDisplay, lightDisplay, message, badEndingText, goodEndingText, score;
public bool winState, isPaused, addedScore;
private static int totalPoints = 0;
public int endingVal;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Ending")){
            Time.timeScale = 1;
            day.SetActive(true);
            night.SetActive(false);
            dayFloor.SetActive(true);
            nightFloor.SetActive(false);
            gameScreen.SetActive(false);
            nextButton.SetActive(false);
            shiftSound = GetComponent<AudioSource>();
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
            t = 0;
            endingVal = 0;
        }
        else{
            message.text = "";
            score.text = "";
            menuButton.SetActive(false);
            if (totalPoints > 60){
                goodEndScreen.color = new Color (1f,1f,1f,1f);
                goodEndingText.enabled = true;
                badEndingText.enabled = false;
            }
            else{           
                badEndScreen.color = new Color (0f,0f,0f,1f);
			    badEndingText.enabled = true;
			    goodEndingText.enabled = false;		
            }
            StartCoroutine(FinalMessage());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(totalPoints > 60);
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Ending")){
            if (Input.GetKeyDown("space") && winState == false && isPaused == false && lb.isFloating == false){
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
            if (endingVal == 0){
                gameScreen.SetActive(true);
                winState = true;
                message.text = "Temple Found";
                if (addedScore == false){
                    totalPoints += lightPoints;
                    totalPoints += darkPoints;
                    addedScore = true;
                }
                StartCoroutine(DisplayScore());
            }
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

        if (endingVal == 1){
            goodEndScreen.color = Color.Lerp(new Color (1f,1f,1f,0f), Color.white, t);
            t += Time.deltaTime / 3;
        }
        if (endingVal == -1){
            badEndScreen.color = Color.Lerp(new Color (1f,1f,1f,0f), Color.black, t);
            t += Time.deltaTime / 3;
        }
        }
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

    public void toEndTransition(){
        if (endingVal == 0){
            if (totalPoints > 60){
                endingVal = 1;
            }
            else{
                endingVal = -1;
            }
        }
        else{
            SceneManager.LoadScene("Ending");
        }
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
    }

    public IEnumerator FinalMessage()
    {
        yield return new WaitForSeconds(23.0f);
        message.text = "Final Score";
        yield return new WaitForSeconds(1.5f);
        score.text = totalPoints + " / 100";
        menuButton.SetActive(true);

    }
}

