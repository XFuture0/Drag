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
    public void OnInitializationComplete()//��ʼ�����
    {
        Debug.Log("��ʼ���ɹ�");
        Advertisement.Load(Interstitial,this);
        Advertisement.Load(Rewarded,this);
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)//��ʼ��ʧ��
    {
        Debug.Log("��ʼ��ʧ��" + message);
    }
    public void OnUnityAdsAdLoaded(string placementId)//���سɹ����
    {
        Debug.Log("���سɹ�");
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)//����ʧ�ܹ��
    {
        Debug.Log("����ʧ��" + message);
    }
    public void OnUnityAdsShowClick(string placementId)//�����
    {
        
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)//���������
    {
      
    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)//������ʧ��
    {
      
    }
    public void OnUnityAdsShowStart(string placementId)//��濪ʼ����
    {

    }
}
