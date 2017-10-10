using UnityEngine;

public class PlayableSdkSample : MonoBehaviour{

    TextMesh mTextMesh;

	// Use this for initialization
	void Start () {
        mTextMesh = GetComponent<TextMesh>();
        InitPlayableAds();
        Debug.Log(gameObject.name);
    }

    private void InitPlayableAds()
    {
        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                AndroidJavaClass sec = new AndroidJavaClass("com.zplay.playable.playableadsplugin.PlayableAdsAdapter");
                sec.CallStatic("InitPA", jo, "androidUnityAppid", "androidUnityAdUnitId");
            }
        }
    }

    public void RequestPlayableAd()
    {
        mTextMesh.text = "request ad";
        RequestAd();
    }

    private void RequestAd()
    {
        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                AndroidJavaClass sec = new AndroidJavaClass("com.zplay.playable.playableadsplugin.PlayableAdsAdapter");
                sec.CallStatic("RequestAd", jo, gameObject.name);
            }
        }
    }

    public void PrensetPlayableAd()
    {
        mTextMesh.text = "present";
        PresentAd();
    }

    private void PresentAd()
    {
        using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                AndroidJavaClass sec = new AndroidJavaClass("com.zplay.playable.playableadsplugin.PlayableAdsAdapter");
                sec.CallStatic("PresentAd", jo, gameObject.name);
            }
        }
    }

    void OnLoadFinished(string msg)
    {
        // 广告加载完成
        mTextMesh.text = msg;
    }

    void OnLoadFailed(string msg)
    {
        // 广告加载失败
        mTextMesh.text = msg;
    }

    void PlayableAdsIncentive(string msg)
    {
        // 广告展示完成，可以发奖励
        mTextMesh.text = msg;
    }

    void OnPresentError(string msg)
    {
        // 广告展示失败
        mTextMesh.text = msg;
    }
}
