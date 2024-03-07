using System;
using UnityEngine;

public class HeroDetect : MonoBehaviour
{
    public delegate void CollisionEvent(Collider2D collider);
    public event CollisionEvent OnEnter;
    public event CollisionEvent OnExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
	if(OnEnter != null)
	{
	    OnEnter(collision);
	}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
	if(OnExit != null)
	{
	    OnExit(collision);
	}
    }

}
