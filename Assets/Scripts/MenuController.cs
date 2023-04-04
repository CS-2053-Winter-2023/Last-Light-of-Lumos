using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public AudioSource menuMusic;
    public GameObject title, start, end, next, background;
    public int gameState;
    public float duration;
    float t;
    Color color1 = new Color(1f,1f,1f,0f);

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        title.SetActive(true);
        menuMusic = GetComponent<AudioSource>();
        menuMusic.Play();
        gameState = 0;
        t = 0;
        start.SetActive(true);
        end.SetActive(true);
        next.SetActive(false);
    }

    public void LoadText(){
        gameState = 1;
        t = 0;
        start.SetActive(false);
        end.SetActive(false);
        next.SetActive(true);
    }

    public void LoadGame(){
        SceneManager.LoadScene("LLOLStage1");
    }

    public void QuitGame(){
        Application.Quit();
    }

    void Update(){
        if (gameState == 0){
            title.GetComponent<SpriteRenderer>().color = Color.Lerp(color1, Color.white, t);
            t += Time.deltaTime / duration;
        }
        if (gameState != 0){
            title.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, color1, t);
            background.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, t);
            t += Time.deltaTime / duration;
        }

    }
}
