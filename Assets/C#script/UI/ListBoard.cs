using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ListBoard : MonoBehaviour
{
    public List<ScoreName> scoreNames;
    public List<int> Counts;
    [Header("������")]
    public Button button;
    private void Start()
    {
        SetData();
    }
    private void OnEnable()
    {
      Counts = GameManager.instance.GetScoreListData();
        button.onClick.AddListener(ADS.instance.NormalADS);
    }
    public void SetData()
    {
        for (int i = 0; i < scoreNames.Count; i++)
        {
            if(i < Counts.Count)
            {
                scoreNames[i].SetScoreText(Counts[i]);//ƥ������
                scoreNames[i].gameObject.SetActive(true);
            }
            else
            {
                scoreNames[i].gameObject.SetActive(false);
            }
        }
    }
}
