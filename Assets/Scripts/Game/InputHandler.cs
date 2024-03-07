using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private static InputController inputControl;
    public static InputController InputControl
    {
        get
        {
            if (inputControl == null)
            {
                inputControl = new InputController();
            }
            return inputControl;
        }
    }

    private void OnEnable()
    {
        InputControl.GamePlayer.Movement.Enable();
        InputControl.GamePlayer.Jump.Enable();
        InputControl.GamePlayer.Attack.Enable();
        InputControl.GamePlayer.Dash.Enable();
        InputControl.UI.Navigate.Enable();
        InputControl.UI.Submit.Enable();

    }

    private void OnDisable()
    {
        InputControl.GamePlayer.Movement.Disable();
        InputControl.GamePlayer.Jump.Disable();
        InputControl.GamePlayer.Attack.Disable();
        InputControl.GamePlayer.Dash.Disable();
        InputControl.UI.Navigate.Disable();
        InputControl.UI.Submit.Disable();
    }
}
