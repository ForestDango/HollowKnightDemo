using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    private CrossFader crossFader;

    private bool isTrigger, keepFadeIn, keepFadeOut;

    private void Awake()
    {
        crossFader = FindObjectOfType<CrossFader>();
    }

    void Update()
    {
        if (Input.anyKeyDown && !isTrigger)
        {
            isTrigger = true;
            StartCoroutine(FadeOut(0.1f));
            StartCoroutine(LoadAsyncNextScene());
        }
    }

    private IEnumerator LoadAsyncNextScene()
    {
        crossFader.FadeOut();
        yield return new WaitForSeconds(1);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu Title");
        do
        {
            yield return null;
        } while (!asyncLoad.isDone);
    }

    private IEnumerator FadeOut(float speed)
    {
        keepFadeIn = false;
        keepFadeOut = true;

        float audioVolume = bgm.volume;

        while (bgm.volume >= 0 && keepFadeOut)
        {
            audioVolume -= speed;
            bgm.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
