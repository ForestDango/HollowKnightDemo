using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTop : MonoBehaviour
{
    public Animator animator;
    public bool isInteractive;

    private void Update()
    {
	//if (isInteractive && Input.GetKeyUp(KeyCode.UpArrow))
	//{
	//    animator.SetTrigger("Active");
	//}
	//if (isInteractive && Input.GetKeyUp(KeyCode.DownArrow))
	//{
	//    animator.SetTrigger("Deactive");
	//}
	if (isInteractive)
	{
	    animator.SetTrigger("Active");
	}
	else
	{
	    animator.SetTrigger("Deactive");
	}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
	//Debug.Log("On Trigger Stay 2D");
	if (!isInteractive && collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
	{
	    isInteractive = true;
	}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("On Trigger Stay 2D");
        if (!isInteractive && collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            isInteractive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
	//Debug.Log("On Trigger Exit 2D");
	if (isInteractive && collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
	{
	    isInteractive = false;
	}
    }

}
