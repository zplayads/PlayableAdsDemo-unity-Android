using UnityEngine;

public class PlayableSdkSample : MonoBehaviour, PlayableAdsHelper.IPlayableAdListener{

    TextMesh mTextMesh;
	PlayableAdsHelper mPlayableAdsHelper;

	// Use this for initialization
	void Start () {
        mTextMesh = GetComponent<TextMesh>();
		mPlayableAdsHelper = PlayableAdsHelper.Init ("androidUnityAppid", "androidUnityAdUnitId", gameObject.name);
		mPlayableAdsHelper.InitPlayableAds();
    }

    public void RequestPlayableAd()
    {
        mTextMesh.text = "request ad";
		mPlayableAdsHelper.RequestAd();
    }

    public void PrensetPlayableAd()
    {
        mTextMesh.text = "present";
		mPlayableAdsHelper.PresentAd ();
    }
		
    public void OnLoadFinished(string msg)
    {
        // 广告加载完成
        mTextMesh.text = msg;
    }

    public void OnLoadFailed(string msg)
    {
        // 广告加载失败
        mTextMesh.text = msg;
    }

    public void PlayableAdsIncentive(string msg)
    {
        // 广告展示完成，可以发奖励
        mTextMesh.text = msg;
    }

    public void OnPresentError(string msg)
    {
        // 广告展示失败
        mTextMesh.text = msg;
    }
}
