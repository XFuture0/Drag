using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UImamager : MonoBehaviour
{
    public GameObject Ending;
    public GameObject ListBoard;
    public Text Score;
    
    private void Start()
    {
        Score.text = "0";
    }
    private void OnEnable()
    {
        Time.timeScale = 1;
        StringEventSO.GetPointEvent += OnGetPoint;
        StringEventSO.GameOverEvent += OnGameOver;
    }

    private void OnGameOver()
    {
        Ending.SetActive(true);
        if (Ending.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
    }

    private void OnGetPoint(int point)
    {
        Score.text = point.ToString();
    }

    private void OnDisable()
    {
        StringEventSO.GetPointEvent -= OnGetPoint;
        StringEventSO.GameOverEvent -= OnGameOver;
    }
    public void RestartGame()
    {
        Ending.SetActive(false);
        TransitionManager.instance.transition("SampleScene");
    }
    public void ReturnGame()
    {
        TransitionManager.instance.transition("Title");
        Ending.SetActive(false);
    }
    public void OpenBoard()
    {
        ListBoard.SetActive(true);
    }
}
