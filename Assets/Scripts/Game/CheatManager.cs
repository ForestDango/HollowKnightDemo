using System;
using System.Collections;
using GlobalEnums;
using UnityEngine.InputSystem;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    private static CheatManager instance;

    private bool isQuickHealEnabled;
    private bool isRegenerating;
    private bool isInstaDeathEnabled; //直接死亡
    private bool isInstaKillEnabled; //直接秒杀

    public static bool IsCheatsEnabled
    {
	get
	{
	    return (Application.platform == RuntimePlatform.Switch || Application.platform == RuntimePlatform.PS4 || Application.platform == RuntimePlatform.XboxOne ||
		Application.platform == RuntimePlatform.WindowsEditor) && (Debug.isDebugBuild || CommandLineArguments.EnableDeveloperCheats);
	}
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
	if (!IsCheatsEnabled)
	{
	    return;
	}
	DontDestroyOnLoad(new GameObject("CheatManager", new Type[]
	{
	    typeof(CheatManager)
	}));
	//PerformanceHUD.Init();
    }

    protected IEnumerator Start()
    {
	instance = this;
	for(; ; )
	{
	    yield return new WaitForSeconds(4f);
	    if (isRegenerating)
	    {
		GameManager unsafeInstance = GameManager.UnsafeInstance;
		if(unsafeInstance != null)
		{
		    HeroController hero_ctrl = HeroController.instance;
		    if(hero_ctrl != null)
		    {
			//TODO:
		    }
		}
	    }
	}
    }

    private void OnDestroy()
    {
	if(instance == this)
	{
	    instance = null;
	}
    }

    private void Update()
    {
	if (Input.GetKeyDown(KeyCode.Home))
	{
	    isInstaKillEnabled = !isInstaKillEnabled;
	    if (isInstaKillEnabled)
	    {
		HeroController.instance.slashDamage = 9999;
	    }
	    else
	    {
		HeroController.instance.slashDamage = 1;
	    }
	}
	if (Input.GetKeyDown(KeyCode.End))
	{
	    isInstaDeathEnabled = !isInstaDeathEnabled;
	    if (isInstaDeathEnabled)
	    {
		if (HeroController.instance.data.GetCurrentHealth() > 0)
		{
		    HeroController.instance.data.health = 0;
		}
	    }
	    else
	    {
		HeroController.instance.data.health = 5;
	    }
	}
    }

}
