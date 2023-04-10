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
	public TextMeshProUGUI badEndingText, goodEndingText;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Ending")){
            if (goodOrBad == 1){
                goodEndScreen.SetActive(true);
                badEndScreen.SetActive(false);
				badEndingText.enabled = false;
				goodEndingText.enabled = true;
            }
            else{
                goodEndScreen.SetActive(false);
                badEndScreen.SetActive(true);
				badEndingText.enabled = true;
				goodEndingText.enabled = false;
				
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
