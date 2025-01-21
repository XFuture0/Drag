using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;
public class ADS : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static ADS instance;
    private string gameID = "5777317";
    private string Interstitial = "Interstitial_Android";
    private string Rewarded = "Rewarded_Android";
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Advertisement.Initialize(gameID, false, this);
    }
    public void GiftADS()
    {
        Advertisement.Show(Rewarded,this);
    }
    public void NormalADS()
    {
        Advertisement.Show(Interstitial,this);
    }
    public void OnInitializationComplete()//初始化完成
    {
        Debug.Log("初始化成功");
        Advertisement.Load(Interstitial,this);
        Advertisement.Load(Rewarded,this);
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)//初始化失败
    {
        Debug.Log("初始化失败" + message);
    }
    public void OnUnityAdsAdLoaded(string placementId)//加载成功广告
    {
        Debug.Log("加载成功");
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)//加载失败广告
    {
        Debug.Log("加载失败" + message);
    }
    public void OnUnityAdsShowClick(string placementId)//广告点击
    {
        
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)//广告加载完成
    {
      
    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)//广告加载失败
    {
      
    }
    public void OnUnityAdsShowStart(string placementId)//广告开始加载
    {

    }
}
