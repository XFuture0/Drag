using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreName : MonoBehaviour
{
    public Text Score;
    public void SetScoreText(int point)
    {
        Score.text = point.ToString();
    }
}
