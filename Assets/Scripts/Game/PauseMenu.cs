using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Animator animator;
    public static bool gameIsPaused = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        animator.Play("FadeIn");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        animator.Play("FadeOut");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
