using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSpikes : MonoBehaviour
{
    public bool isTrigger;

    private HazardRespawn respawner;
    private HeroController character;
    private PlayerData data;

    private void Awake()
    {
        if (respawner == null)
        {
            respawner = FindObjectOfType<HazardRespawn>();
        }
        if (data == null)
        {
            data = FindObjectOfType<PlayerData>();
        }
	if (character == null)
        {
            character = FindObjectOfType<HeroController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTrigger && collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            Attack();
        }
    }

    public void Attack()
    {
        isTrigger = true;
        StartCoroutine(character.TakeDamage());
        if (data.GetDeadStatement())
        {
            respawner.Respawn(this);
        }
        else
        {
            respawner.BackToAlivePoint(this);
        }
    }
}
