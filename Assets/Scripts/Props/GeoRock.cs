using System;
using UnityEngine;

public class GeoRock : Breakable
{
    [SerializeField] private GameObject coin;
    [SerializeField] private int minSpawnCount = 1;
    [SerializeField] private int maxSpawnCount = 4;
    [SerializeField] private float maxBumpHorizontalForce = 400;
    [SerializeField] private float minBumpVerticalForce = 600;
    [SerializeField] private float maxBumpVerticalForce = 800;
    [SerializeField] private ParticleSystem leftParticle;
    [SerializeField] private ParticleSystem rightParticle;
    [SerializeField] private ParticleSystem upParticle;
    [SerializeField] private ParticleSystem burstRocks;

    private Animator animator;
    private AudioSource audioSource;
    private int animationHurtTrigger;
    private int animationDeadTrigger;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        animationHurtTrigger = Animator.StringToHash("Hurt");
        animationDeadTrigger = Animator.StringToHash("Dead");
    }

    private void Update()
    {
        CheckIsDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            Hurt(1, FindObjectOfType<HeroAttack>().transform);
        }
    }

    public override void Hurt(int damage, Transform attackPosition)
    {
        base.Hurt(damage, attackPosition);
        Vector2 vector = attackPosition.position - transform.position;
        if (vector.x > 0)
        {
            leftParticle.Play();
        }
        else
        {
            rightParticle.Play();
        }
        SpawnCoins();
        animator.SetTrigger(animationHurtTrigger);
    }

    protected override void Dead()
    {
        base.Dead();
        leftParticle.Play();
        rightParticle.Play();
        upParticle.Play();
        burstRocks.Play();
        animator.SetTrigger(animationDeadTrigger);
    }

    public void PlayHurtAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    private void SpawnCoins()
    {
        int randomCount = UnityEngine.Random.Range(minSpawnCount, maxSpawnCount + 1);
        for (int i = 0; i < randomCount; i++)
        {
            GameObject geo = Instantiate(coin, transform.position, Quaternion.identity, transform) as GameObject;
            Vector2 force = new Vector2(UnityEngine.Random.Range(-maxBumpHorizontalForce, maxBumpHorizontalForce), UnityEngine.Random.Range(minBumpVerticalForce, maxBumpVerticalForce));
            geo.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
        }
    }
}
