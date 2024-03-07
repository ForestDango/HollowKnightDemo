using System;
using GlobalEnums;
using UnityEngine;

[Serializable]
public class GameSetting
{
    private bool verboseMode;

    #region Keyboard Settings 键盘按键设置

    [Header("Keyboard Settings")]
    public string jumpKey;//跳跃键
    public string attackKey;//攻击键
    public string dashKey;//冲刺键
    public string castKey;//法术键
    public string superDashKey;//超级冲刺键
    public string dreamNailKey;//梦之钉键
    public string quickMapKey;//查看地图键
    public string quickCastKey;//快速法术攻击键
    public string inventoryKey;//背包键
    public string upKey;//上键
    public string downKey;//下键
    public string leftKey;//左键
    public string rightKey;//右键

    #endregion

    public GameSetting()
    {
	verboseMode = false;
    }

   
    #region Public Health Methods 公有的辅助方法

    /// <summary>
    /// 加载Int类型的数据
    /// </summary>
    /// <param name="key"></param>
    /// <param name="val"></param>
    /// <param name="def"></param>
    /// <returns></returns>
    private bool LoadInt(string key, ref int val, int def)
    {
	if (Platform.Current.SharedData.HasKey(key))
	{
	    val = Platform.Current.SharedData.GetInt(key, def);
	    if (verboseMode)
	    {
		LogLoadedKey(key, val);
	    }
	    return true;
	}
	val = def;
	if (verboseMode)
	{
	    LogMissingKey(key);
	}
	return false;
    }

    /// <summary>
    /// 返回是否有key关键字的数据
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private bool HasSetting(string key)
    {
	return Platform.Current.SharedData.HasKey(key);
    }

    /// <summary>
    /// 加载Enum类型的数据
    /// </summary>
    /// <typeparam name="EnumTy"></typeparam>
    /// <param name="key"></param>
    /// <param name="val"></param>
    /// <param name="def"></param>
    /// <returns></returns>
    private bool LoadEnum<EnumTy>(string key, ref EnumTy val, EnumTy def)
    {
	int num = (int)((object)val);
	bool result = LoadInt(key, ref num, (int)((object)def));
	val = (EnumTy)((object)num);
	return result;
    }

    /// <summary>
    /// 加载Bool类型的数据
    /// </summary>
    /// <param name="key"></param>
    /// <param name="val"></param>
    /// <param name="def"></param>
    /// <returns></returns>
    private bool LoadBool(string key, ref bool val, bool def)
    {
	int num = val ? 1 : 0;
	bool result = LoadInt(key, ref num, def ? 1 : 0);
	val = (num > 0);
	return result;
    }

    /// <summary>
    /// 加载Float类型的数据
    /// </summary>
    /// <param name="key"></param>
    /// <param name="val"></param>
    /// <param name="def"></param>
    /// <returns></returns>
    private bool LoadFloat(string key, ref float val, float def)
    {
	if (Platform.Current.SharedData.HasKey(key))
	{
	    val = Platform.Current.SharedData.GetFloat(key, def);
	    if (verboseMode)
	    {
		LogLoadedKey(key, val);
	    }
	    return true;
	}
	val = def;
	if (verboseMode)
	{
	    LogMissingKey(key);
	}
	return false;
    }

    /// <summary>
    /// 加载String类型的数据
    /// </summary>
    /// <param name="key"></param>
    /// <param name="val"></param>
    /// <param name="def"></param>
    /// <returns></returns>
    private bool LoadString(string key, ref string val, string def)
    {
	if (Platform.Current.SharedData.HasKey(key))
	{
	    val = Platform.Current.SharedData.GetString(key, def);
	    if (verboseMode)
	    {
		LogLoadedKey(key, val);
	    }
	    return true;
	}
	val = def;
	if (verboseMode)
	{
	    LogMissingKey(key);
	}
	return false;
    }

    /// <summary>
    /// 记录无法找到的Key键(无法通过Key找到相信的值)
    /// </summary>
    /// <param name="key"></param>
    private void LogMissingKey(string key)
    {
	Debug.LogFormat("LoadSettings - {0} setting not found. Loading defaults.", new object[]
	{
	    key
	});
    }

    /// <summary>
    ///  记录加载的Key键(值为int类型)通过Key加载int类型的值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    private void LogLoadedKey(string key, int value)
    {
	Debug.LogFormat("LoadSettings - {0} Loaded ({1})", new object[]
	{
	    key,
	    value
	});
    }

    /// <summary>
    ///  记录加载的Key键(值为float类型)通过Key加载float类型的值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    private void LogLoadedKey(string key, float value)
    {
	Debug.LogFormat("LoadSettings - {0} Loaded ({1})", new object[]
	{
	    key,
	    value
	});
    }

    /// <summary>
    /// 记录加载的Key键(值为string类型)通过Key加载string类型的值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    private void LogLoadedKey(string key, string value)
    {
	Debug.LogFormat("LoadSettings - {0} Loaded ({1})", new object[]
	{
	    key,
	    value
	});
    }

    /// <summary>
    /// 记录保存的Key键(值为int类型) Key与int类型的值绑定
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    private void LogSavedKey(string key, int value)
    {
	Debug.LogFormat("SaveSettings - {0} Saved ({1})", new object[]
	{
	    key,
	    value
	});
    }
    /// <summary>
    /// 记录保存的Key键(值为float类型) Key与float类型的值绑定
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    private void LogSavedKey(string key, float value)
    {
	Debug.LogFormat("SaveSettings - {0} Saved ({1})", new object[]
	{
	    key,
	    value
	});
    }
    /// <summary>
    /// 记录保存的Key键(值为string类型) Key与string类型的值绑定
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    private void LogSavedKey(string key, string value)
    {
	Debug.LogFormat("SaveSettings - {0} Saved ({1})", new object[]
	{
	    key,
	    value
	});
    }

    public bool CommandArgumentUsed(string arg)
    {
	string[] commandLineArgs = Environment.GetCommandLineArgs();
	if (commandLineArgs == null)
	{
	    return false;
	}
	string[] array = commandLineArgs;
	for (int i = 0; i < array.Length; i++)
	{
	    if (array[i].Equals(arg))
	    {
		return true;
	    }
	}
	return false;
    }

    #endregion

}
