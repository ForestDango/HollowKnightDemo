using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private HeroController character;

    private void Awake()
    {
        character = FindObjectOfType<HeroController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            character.SetIsOnGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            character.SetIsOnGrounded(false);
        }
    }
}
