using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingScript : MonoBehaviour
{
    public int goodOrBad = 0;
    public GameObject goodEndScreen, badEndScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Ending")){
            if (goodOrBad == 1){
                goodEndScreen.SetActive(true);
                badEndScreen.SetActive(false);
            }
            else{
                goodEndScreen.SetActive(false);
                badEndScreen.SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
