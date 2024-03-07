using System;
using UnityEngine;

public class DontDestoryGameObject : MonoBehaviour
{
    private void Awake()
    {
	DontDestroyOnLoad(gameObject);
    }
}
