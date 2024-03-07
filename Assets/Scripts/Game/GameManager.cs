using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager instance
    {
	get
	{
            if(_instance == null)
	    {
                _instance = FindObjectOfType<GameManager>();
                if(_instance == null)
		{
                    Debug.LogError("Couldn't find a Game Manager, make sure one exists in the scene.");
                }
                else if(Application.isPlaying)
		{
                    DontDestroyOnLoad(_instance.gameObject);
		}
	    }
            return _instance;
	}
    }
    public static GameManager UnsafeInstance
    {
	get
	{
            return _instance;
	}
    }

    [SerializeField] public PlayerData playerData;

    private bool enableInput = true;
    private bool waiting = false;

    public float sceneWidth;
    public float sceneHeight;

    private void Awake()
    {
	if(_instance == null)
	{
            _instance = this;
            DontDestroyOnLoad(this);
            SetupGameRefs();
            return;
	}
        if(this != _instance)
	{
            Destroy(gameObject);
            return;
	}

    }

    private void SetupGameRefs()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    public void Stop(float duration, float timeScale)
    {
        if (waiting)
            return;
        Time.timeScale = timeScale;
        StartCoroutine(Wait(duration));
    }
    public void Stop(float duration)
    {
        Stop(duration, 0.0f);
    }
    private IEnumerator Wait(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }
    public bool IsEnableInput()
    {
        return enableInput;
    }
    public void SetEnableInput(bool enabled)
    {
        enableInput = enabled;
    }
}
