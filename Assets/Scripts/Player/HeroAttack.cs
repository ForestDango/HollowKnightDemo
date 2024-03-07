using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] private ContactFilter2D enemyContactFilter;
    [Header("攻击范围检测")]
    [SerializeField] private GameObject slash;
    [SerializeField] private GameObject altSlash;
    [SerializeField] private GameObject downSlash;
    [SerializeField] private GameObject upSlash;
    [SerializeField] private GameObject cycloneSlash;
    [SerializeField] private GameObject wallSlash;
    [SerializeField] private GameObject greatSlash;
    [SerializeField] private GameObject dashSlash;
    [SerializeField] private GameObject sharpShadow;

    public enum AttackType
    {
        Slash,
        AltSlash, 
        DownSlash, 
        UpSlash, 
        CycloneSlash, 
        WallSlash, 
        GreatSlash, 
        DashSlash,
        SharpShadow,
    }

    public void Play(AttackType attackType, ref List<Collider2D> colliders)
    {
        switch (attackType)
        {
            case AttackType.Slash:
                Physics2D.OverlapCollider(slash.GetComponent<Collider2D>(), enemyContactFilter, colliders);
                slash.GetComponent<AudioSource>().Play();
                break;
            case AttackType.AltSlash:
                Physics2D.OverlapCollider(altSlash.GetComponent<Collider2D>(), enemyContactFilter, colliders);
                altSlash.GetComponent<AudioSource>().Play();
                break;
            case AttackType.DownSlash:
                Physics2D.OverlapCollider(downSlash.GetComponent<Collider2D>(), enemyContactFilter, colliders);
                downSlash.GetComponent<AudioSource>().Play();
                break;
            case AttackType.UpSlash:
                Physics2D.OverlapCollider(upSlash.GetComponent<Collider2D>(), enemyContactFilter, colliders);
                upSlash.GetComponent<AudioSource>().Play();
                break;
            case AttackType.CycloneSlash:
                break;
            case AttackType.WallSlash:
                break;
            case AttackType.GreatSlash:
                break;
            case AttackType.DashSlash:
                break;
            case AttackType.SharpShadow:
                break;
            default:
                break;
        }
    }
}
