using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //�б�������
    private string DataPath;
    public List<int> scoreList;
    private int CurrScore;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DataPath = Application.persistentDataPath + "/ScoreData.Json";//��������·��
        scoreList = GetScoreListData();
        DontDestroyOnLoad(this);
    }
    private void OnEnable()
    {
        StringEventSO.GameOverEvent += OnGameOver;
        StringEventSO.GetPointEvent += OnGetpoint;
    }
    private void OnGetpoint(int score)
    {
        CurrScore = score;
    }
    private void OnGameOver()
    {
        if (!scoreList.Contains(CurrScore))
        {
            scoreList.Add(CurrScore);
        }
        scoreList.Sort();//�Ӵ�С����
        scoreList.Reverse();//����
        File.WriteAllText(DataPath,JsonConvert.SerializeObject(scoreList));//���л����ݱ���
    }
    public List<int> GetScoreListData()
    {
        if (File.Exists(DataPath))
        {
            var jsondata = File.ReadAllText(DataPath);
            return JsonConvert.DeserializeObject<List<int>>(jsondata);//�����л�
        }
        return new List<int>();//���ؿ��б�
    }
    private void OnDisable()
    {
        StringEventSO.GameOverEvent -= OnGameOver;
        StringEventSO.GetPointEvent -= OnGetpoint;
    }
}
