using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geo : MonoBehaviour
{
    [SerializeField] private AudioClip[] geoHitGrounds;
    private AudioSource audioSource;
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;

    public bool isGrounded;

    private float defaultGravity;

    private void Awake()
    {
	audioSource = GetComponent<AudioSource>();
	body = GetComponent<Rigidbody2D>();
	boxCollider = GetComponent<BoxCollider2D>();

	defaultGravity = body.gravityScale;
    }

    private void OnEnable()
    {
	boxCollider.isTrigger = false;
	transform.SetPositionZ(UnityEngine.Random.Range(0.001f,0.002f));
	body.gravityScale = defaultGravity;
    }

    private void Start()
    {
	
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	if (!isGrounded && (collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrain") || collision.gameObject.layer == LayerMask.NameToLayer("Terrain")))
	{
	    isGrounded = true;
	    int index = UnityEngine.Random.Range(0, geoHitGrounds.Length);
	    audioSource.PlayOneShot(geoHitGrounds[index]);
	}
    }

    [Serializable]
    public struct Size
    {
	public string idleAnim;
	public string airAnim;
	public int value;
	public Size(string idleAnim, string airAnim, int value)
	{
	    this.idleAnim = idleAnim;
	    this.airAnim = airAnim;
	    this.value = value;
	}
    }
}
