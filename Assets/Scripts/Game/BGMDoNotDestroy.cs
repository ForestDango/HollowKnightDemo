using System;
using UnityEngine;

public class BGMDoNotDestroy : MonoBehaviour
{
    private AudioSource bgm;

    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
    }

    public void Play()
    {
        bgm.Play();
    }
}
