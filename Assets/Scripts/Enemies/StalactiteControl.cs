using System;
using System.Collections;
using UnityEngine;

public class StalactiteControl : MonoBehaviour
{
    public GameObject top;

    [Space]
    public float startFallOffset = 0.1f;
    public GameObject startFallEffect;
    public AudioClip startFallSound;

    public float fallDelay = 0.25f;

    [Space]
    public GameObject fallEffect;
    public GameObject trailEffect;

    [Space]
    public GameObject embeddedVersion;

    [Space]
    public float hitVelocity = 40f;

    private DamageHero heroDamage;
    private Rigidbody2D body;
    private AudioSource source;
    //private DamageEnemies damageEnemies;

    [SerializeField] private bool fallen;
    [SerializeField] private bool hasBeenHurtHero;

    private void Awake()
    {
	body = GetComponent<Rigidbody2D>();
	source = GetComponent<AudioSource>();
	heroDamage = GetComponent<DamageHero>();
    }

    private void Start()
    {
	if (heroDamage)
	{
	    heroDamage.damageDealt = 0;
	}
	body.isKinematic = true;
	
    }

    public IEnumerator Fall(float fallDelay)
    {
	if (top)
	{
	    top.transform.SetParent(transform.parent);
	}
	transform.position += Vector3.down * startFallOffset;
	if (startFallEffect)
	{
	    startFallEffect.SetActive(true);
	    startFallEffect.transform.SetParent(transform.parent);
	}
	if(source && startFallSound)
	{
	    source.PlayOneShot(startFallSound);
	}
	yield return new WaitForSeconds(fallDelay);
	if (fallEffect)
	{
	    fallEffect.SetActive(true);
	    fallEffect.transform.SetParent(transform.parent);
	}
	if (trailEffect)
	{
	    trailEffect.SetActive(true);
	}
	if (heroDamage)
	{
	    heroDamage.damageDealt = 1;
	}

	body.isKinematic = false;
	fallen = true;
	yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
	if (fallen && collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
	{
	    hasBeenHurtHero = !hasBeenHurtHero; 
	    if (!HeroController.instance.data.GetDeadStatement() && hasBeenHurtHero)
	    {
		Debug.Log("Hurt Player!");
		StartCoroutine(HeroController.instance.TakeDamage());
		//StartCoroutine(FindObjectOfType<Invincibility>().SetInvincibility());
	    }
	}
	if(fallen && collision.gameObject.layer == LayerMask.NameToLayer("Enemy Detector"))
	{
	    collision.gameObject.GetComponent<Enemy>().SetInstaDead();
	}
	else if (fallen && collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
	{
	    body.isKinematic = true;
	    if (trailEffect)
	    {
		trailEffect.transform.SetParent(null);
	    }
	    trailEffect.GetComponent<ParticleSystem>().Stop();
	    if (embeddedVersion)
	    {
		embeddedVersion.SetActive(true);
		embeddedVersion.transform.SetParent(transform.parent, true);
	    }

	    base.gameObject.SetActive(false);
	    return;
	}
    }

}
