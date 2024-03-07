using Com.LuisPedroFonseca.ProCamera2D;
using System;
using UnityEngine;

public class Collapser : MonoBehaviour
{
    private HeroController characterController;
    private GameManager gameManager;
    private Animator animator;
    private AudioSource audioPlayer;
    private Collider2D[] cols;
    private bool isTrigger;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        characterController = FindObjectOfType<HeroController>();
        cols = GetComponentsInChildren<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTrigger && collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            isTrigger = true;
            animator.Play("Fall");
            audioPlayer.Play();
        }
    }

    public void StartShake()
    {
        var shakePreset = ProCamera2DShake.Instance.ConstantShakePresets[0];
        ProCamera2DShake.Instance.ConstantShake(shakePreset);
    }

    public void StopShake()
    {
        ProCamera2DShake.Instance.StopConstantShaking();
    }

    public void StopInput()
    {
        gameManager.SetEnableInput(false);
        characterController.StopHorizontalMovement();
    }

    public void ResumeInput()
    {
        gameManager.SetEnableInput(true);
    }

    public void DisableColliders()
    {
        foreach (Collider2D c in cols)
        {
            c.enabled = false;
        }
    }
}
