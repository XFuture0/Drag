using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //列表保存数据
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

        DataPath = Application.persistentDataPath + "/ScoreData.Json";//保存数据路径
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
        scoreList.Sort();//从大到小排列
        scoreList.Reverse();//反向
        File.WriteAllText(DataPath,JsonConvert.SerializeObject(scoreList));//序列化数据保存
    }
    public List<int> GetScoreListData()
    {
        if (File.Exists(DataPath))
        {
            var jsondata = File.ReadAllText(DataPath);
            return JsonConvert.DeserializeObject<List<int>>(jsondata);//反序列化
        }
        return new List<int>();//返回空列表
    }
    private void OnDisable()
    {
        StringEventSO.GameOverEvent -= OnGameOver;
        StringEventSO.GetPointEvent -= OnGetpoint;
    }
}
