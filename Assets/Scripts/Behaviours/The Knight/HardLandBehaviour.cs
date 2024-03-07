﻿using Com.LuisPedroFonseca.ProCamera2D;
using System;
using UnityEngine;


public class HardLandBehaviour : StateMachineBehaviour
{
     private HeroAudioController sound;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 相机震动
        var shakePreset = ProCamera2DShake.Instance.ShakePresets[2];
        ProCamera2DShake.Instance.Shake(shakePreset);
        if (sound == null)
            FindObjectOfType<HeroAudioController>().Play(HeroAudioController.AudioType.HardLanding, true);
        else
            sound.Play(HeroAudioController.AudioType.HardLanding, true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
