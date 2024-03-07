using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuButton : UIButton
{
    [SerializeField] PauseMenuButtonController menuButtonController;
    [SerializeField] PauseMenuButtonController.PauseMenuButtonConstant mainMenuButton;

    private void Update()
    {
        if (menuButtonController.index == (int)mainMenuButton)
        {
            animator.SetBool("selected", true);
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }

    public override void MousePointerEnter()
    {
        menuButtonController.index = (int)mainMenuButton;
        base.MousePointerEnter();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void MousePointerExit()
    {
        base.MousePointerExit();
    }

    public override void MousePointerClick()
    {
        base.MousePointerClick();
        menuButtonController.Pressed();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
