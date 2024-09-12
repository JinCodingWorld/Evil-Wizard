using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class testSurviveTime
{
    public static Text timeText;
    public static float surviveTime;
}

public class SurviveTime : MonoBehaviour
{
    void Start()
    {
        testSurviveTime.surviveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        testSurviveTime.surviveTime += Time.deltaTime;
        //testSurviveTime.timeText.text = "Time : " + (int)testSurviveTime.surviveTime;
    }
}
