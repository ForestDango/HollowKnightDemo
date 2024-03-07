using System;
using UnityEngine;

public class HazardRespawnTrigger : MonoBehaviour
{
    private HazardRespawn hazardRespawn;

    private void Awake()
    {
        hazardRespawn = FindObjectOfType<HazardRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            hazardRespawn.hazardRespawnTrigger = this;
        }
    }
}
