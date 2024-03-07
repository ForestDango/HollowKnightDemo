using System;
using System.Text;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    private static Platform current;
    public static Platform Current
    {
	get
	{
	    return current;
	}
    }
    protected virtual void OnDestroy()
    {
    }
    protected virtual void Update()
    {	
    }

    public abstract ISharedData SharedData { get; }
    public abstract ISharedData EncryptedSharedData { get; }

    public interface ISharedData
    {
	bool HasKey(string key);
	void DeleteKey(string key);
	void DeleteAll();
	bool GetBool(string key, bool def);
	void SetBool(string key, bool val);
	int GetInt(string key, int def);
	void SetInt(string key, int val);
	float GetFloat(string key, float def);
	void SetFloat(string key, float val);
	string GetString(string key, string def);
	void SetString(string key, string val);
	void Save();
    }

    public enum GraphicsTiers
    {
	VeryLow = 0,
	Low = 1,
	Medium = 2,
	High = 3
    }
    public enum AcceptRejectInputStyles
    {
	NonJapaneseStyle = 0,
	JapaneseStyle = 1
    }
    public enum MenuActions
    {
	None = 0,
	Submit = 1,
	Cancel = 2
    }
    public enum EngagementRequirements
    {
	Invisible = 0,
	MustDisplay = 1
    }
    public enum EngagementStates
    {
	NotEngaged = 0,
	EngagePending = 1,
	Engaged = 2
    }
    public interface IDisengageHandler
    {
	void OnDisengage(Action next);
    }
}
