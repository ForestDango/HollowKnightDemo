using System;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindObjectOfType<GameSceneManager>();
    }

    public void DelayLoadNextScene()
    {
        gameSceneManager.DelayLoadNextScene();
    }
}
