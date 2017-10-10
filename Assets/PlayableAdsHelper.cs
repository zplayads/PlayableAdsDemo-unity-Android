using System;
using UnityEngine;

// 不要修改本文件内容
public class PlayableAdsHelper
{
	private string objName;
	private string appId;
	private string unitId;

	private PlayableAdsHelper (string appId, string unitId, string objName)
	{
		this.objName = objName;
		this.appId = appId;
		this.unitId = unitId;
	}

	private static PlayableAdsHelper instance;

	public static PlayableAdsHelper Init(string appId, string unitId, string objName)
	{
		if (instance == null) 
		{
			instance = new PlayableAdsHelper (appId, unitId, objName);
		}
		instance.appId = appId;
		instance.unitId = unitId;
		instance.objName = objName;
		return instance;
	}

	public void InitPlayableAds()
	{
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
			{
				AndroidJavaClass sec = new AndroidJavaClass("com.zplay.playable.playableadsplugin.PlayableAdsAdapter");
				sec.CallStatic("InitPA", jo, appId, unitId);
			}
		}
	}

	public void RequestAd()
	{
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
			{
				AndroidJavaClass sec = new AndroidJavaClass("com.zplay.playable.playableadsplugin.PlayableAdsAdapter");
				sec.CallStatic("RequestAd", jo, objName);
			}
		}
	}

	public void PresentAd()
	{
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
			{
				AndroidJavaClass sec = new AndroidJavaClass("com.zplay.playable.playableadsplugin.PlayableAdsAdapter");
				sec.CallStatic("PresentAd", jo, objName);
			}
		}
	}

	public interface IPlayableAdListener
	{
void OnLoadFinished(string msg);

void OnLoadFailed(string msg);

void PlayableAdsIncentive(string msg);

void OnPresentError(string msg);
	}
}