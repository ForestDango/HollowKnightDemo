using System;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    public GameObject heroDashPuff;
    public GameObject dashDust;
    public GameObject dashBone;
    public GameObject dashGrass;
    public GameObject waterCut;

    public AudioClip dashClip;

    private PlayerData pd;
    private GameObject heroObject;
    private AudioSource audioSource;

    private float recycleTimer;

    private void OnEnable()
    {
	if(pd == null)
	{
	    pd = GameManager.instance.playerData;
	}
	if(audioSource == null)
	{
	    audioSource = gameObject.GetComponent<AudioSource>();
	}
	foreach (object obj in transform)
	{
	    ((Transform)obj).gameObject.SetActive(false);
	}
	recycleTimer = 1f;
	HeroController instance = HeroController.instance;
	if(instance != null)
	{

	}
    }

    private void Update()
    {
	if(recycleTimer <= 0f)
	{
	    Destroy(gameObject);
	    return;
	}
	recycleTimer -= Time.deltaTime;
    }

    private void PlayDashPuff()
    {
	heroDashPuff.SetActive(true);
    }
    private void PlayDust()
    {
	dashDust.SetActive(true);
    }
    private void PlayGrass()
    {
	dashGrass.SetActive(true);
    }

    private void PlayBone()
    {
	dashBone.SetActive(true);
    }

    private void PlaySpaEffects()
    {
	waterCut.SetActive(true);
    }
}
