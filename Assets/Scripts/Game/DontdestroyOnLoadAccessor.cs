using System;
using UnityEngine;

public class DontdestroyOnLoadAccessor : MonoBehaviour
{
    private static DontdestroyOnLoadAccessor _instance;
    public static DontdestroyOnLoadAccessor Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null) Destroy(this);
        this.gameObject.name = this.GetType().ToString();
        _instance = this;
        DontDestroyOnLoad(this);
    }

    public GameObject[] GetAllRootsOfDontDestroyOnLoad()
    {
        return this.gameObject.scene.GetRootGameObjects();
    }
}

public class FindDontDestroyOnLoad : MonoBehaviour
{
    public GameObject[] rootsFromDontDestroyOnLoad;
    void Start()
    {
        rootsFromDontDestroyOnLoad = DontdestroyOnLoadAccessor.Instance.GetAllRootsOfDontDestroyOnLoad();
    }
}