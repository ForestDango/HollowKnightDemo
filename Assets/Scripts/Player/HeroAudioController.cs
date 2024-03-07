using System;
using UnityEngine;
using UnityEngine.Audio;

public class HeroAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource mainEffectAudioSouce = null;
    [Header("Audio Sources")]
    [SerializeField] private AudioSource hardLandingAudioSource = null;
    [SerializeField] private AudioSource jumpAudioSource = null;
    [SerializeField] private AudioSource takeHitAudioSource = null;
    [SerializeField] private AudioSource landingAudioSource = null;
    [SerializeField] private AudioSource backDashAudioSource = null;
    [SerializeField] private AudioSource dashAudioSource = null;
    [SerializeField] private AudioSource fallingAudioSource = null;
    [SerializeField] private AudioSource footstepsRunAudioSource = null;
    [SerializeField] private AudioSource footstepsWalkAudioSource = null;
    [SerializeField] private AudioSource wallSlideAudioSource = null;
    [SerializeField] private AudioSource nailArtChargeAudioSource = null;
    [SerializeField] private AudioSource nailArtReadyAudioSource = null;
    [SerializeField] private AudioSource slugWalkAudioSource = null;
    [SerializeField] private AudioSource superDashingAudioSource = null;
    [SerializeField] private AudioSource superDashChargeAudioSource = null;
    [SerializeField] private AudioSource dreamNailAudioSource = null;
    [SerializeField] private AudioSource swimAudioSource = null;
    [SerializeField] private AudioSource wallJumpAudioSource = null;
    [SerializeField] private AudioSource heroDamageAudioSource = null;
    [SerializeField] private AudioSource heroWingsAudioSource = null;
    [Header("Audio Clips")]
    [SerializeField] private AudioClip swordHitReject = null;
    public void Play(AudioType audioType, bool playState)
    {
        AudioSource audioSource = null;
        switch (audioType)
        {
            case AudioType.HardLanding:
                audioSource = hardLandingAudioSource;
                break;
            case AudioType.Jump:

                audioSource = jumpAudioSource;
                break;
            case AudioType.TakeHit:
                audioSource = takeHitAudioSource;
                break;
            case AudioType.Landing:
                audioSource = landingAudioSource;
                break;
            case AudioType.BackDash:
                audioSource = backDashAudioSource;
                break;
            case AudioType.Dash:
                audioSource = dashAudioSource;
                break;
            case AudioType.Falling:
                audioSource = fallingAudioSource;
                break;
            case AudioType.FootstepsRun:
                audioSource = footstepsRunAudioSource;
                break;
            case AudioType.FoorstepsWalk:
                audioSource = footstepsWalkAudioSource;
                break;
            case AudioType.WallSlide:
                audioSource = wallSlideAudioSource;
                break;
            case AudioType.NailArtCharge:
                audioSource = nailArtChargeAudioSource;
                break;
            case AudioType.NailArtReady:
                audioSource = nailArtReadyAudioSource;
                break;
            case AudioType.SlugWalk:
                audioSource = slugWalkAudioSource;
                break;
            case AudioType.SuperDashing:
                audioSource = superDashingAudioSource;
                break;
            case AudioType.SuperDashCharge:
                audioSource = superDashChargeAudioSource;
                break;
            case AudioType.DreamNail:
                audioSource = dreamNailAudioSource;
                break;
            case AudioType.Swim:
                audioSource = swimAudioSource;
                break;
            case AudioType.WallJump:
                audioSource = wallJumpAudioSource;
                break;
            case AudioType.HeroDamage:
                audioSource = heroDamageAudioSource;
                break;
            case AudioType.HeroWings:
                audioSource = heroWingsAudioSource;
                break;
        }
        if (audioSource != null)
        {
            if (playState)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    public void PlayJump()
    {
        jumpAudioSource.Play();
    }

    public void PlayOneShot(AudioClipType audioType)
    {
        switch (audioType)
        {
            case AudioClipType.SwordHitReject:
                mainEffectAudioSouce.PlayOneShot(swordHitReject);
                break;
        }
    }

    public enum AudioType
    {
        HardLanding,
        Jump,
        TakeHit,
        Landing,
        BackDash,
        Dash, 
        Falling, 
        FootstepsRun,
        FoorstepsWalk,
        WallSlide,
        NailArtCharge,
        NailArtReady, 
        SlugWalk,
        SuperDashing,
        SuperDashCharge,
        DreamNail,
        Swim, 
        WallJump, 
        HeroDamage, 
        HeroWings,
    }

    public enum AudioClipType
    {
        SwordHitReject,
    }

}
