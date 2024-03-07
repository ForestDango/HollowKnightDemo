using System;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
	if(Input.GetAxisRaw("Horizontal") != 0f)
	{
	    Vector3 eulerAngle = base.transform.eulerAngles;
	    eulerAngle.y += Input.GetAxisRaw("Horizontal") * speed;
	    transform.eulerAngles = eulerAngle;
	}
    }
}
