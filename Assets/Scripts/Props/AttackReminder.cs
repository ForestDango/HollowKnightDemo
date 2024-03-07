﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackReminder : MonoBehaviour
{
    public GameObject obj;
    public Animator reminder;
    private float timer;
    private bool needTutorial;

    private void Update()
    {
        if (needTutorial && obj.activeSelf)
        {
            if (timer >= 0.5f)
            {
                reminder.SetTrigger("FadeIn");
                needTutorial = false;
            }
            else
            {
                timer += Time.deltaTime;
                reminder.ResetTrigger("FadeIn");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector") && obj.activeSelf && !needTutorial)
        {
            needTutorial = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
	if (needTutorial)
	{
            needTutorial = false;
	}
    }

}
