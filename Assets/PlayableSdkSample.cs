using UnityEngine;

public class PlayableSdkSample : MonoBehaviour, PlayableAdsHelper.IPlayableAdListener{

    TextMesh mTextMesh;
	PlayableAdsHelper mPlayableAdsHelper;

	// Use this for initialization
	void Start () {
        mTextMesh = GetComponent<TextMesh>();
		// 将androidUnityAppid／androidUnityAdUnitId替换为通过审核的appId和广告位Id
		mPlayableAdsHelper = PlayableAdsHelper.Init ("androidUnityAppid", "androidUnityAdUnitId", gameObject.name);
		mPlayableAdsHelper.InitPlayableAds();
    }

    public void RequestPlayableAd()
    {
        mTextMesh.text = "request ad";
		// 调用该方法请求广告
		// 每次请求的广告只能展示一次，展示完后该广告会过期。再次调用该方法会请求新的广告。
		mPlayableAdsHelper.RequestAd();
    }

    public void PrensetPlayableAd()
    {
        mTextMesh.text = "present";
		// 调用该方法展示广告
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
