using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour
{
    public AudioSource bgMusic;
    public GameController gC;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic.GetComponent<AudioSource>();
        bgMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gC.endingVal != 0){
            StartCoroutine(FadeOut(bgMusic,2f));
        }
    }

    public static IEnumerator FadeOut(AudioSource audio, float fadeTime)
    {
        float startVolume = audio.volume;
        while (audio.volume > 0){
            audio.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audio.Stop();
    }
}
