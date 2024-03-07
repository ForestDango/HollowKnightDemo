using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class HitEffect : MonoBehaviour
{
    private Animator effectAnimator;

    private void Start()
    {
        effectAnimator = GetComponent<Animator>();
    }

    public void PlayHitAnimation()
    {
        effectAnimator.Play("Hit");
    }
}
