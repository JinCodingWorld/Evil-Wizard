using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text recordText;
    public Text survivalTime;
    private void Start()
    {
        testScoreManger();
    }
    public void testScoreManger()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (testSurviveTime.surviveTime < bestTime)
        {
            bestTime = testSurviveTime.surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time : " + (int)bestTime;
        survivalTime.text = "YOUR RECORD : " + (int)testSurviveTime.surviveTime;
    }
}

