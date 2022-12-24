using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static float timerMinut;
    public static float timerSecond;
    public Text TextTimer;

    private void Update()
    {
        timerSecond += Time.deltaTime;
        TextTimer.text = timerMinut.ToString() +":"+ timerSecond.ToString("F0");
        if (timerSecond > 60)
        {
            Debug.Log(timerSecond);
            timerSecond = 0;
            timerMinut += 1;
        }
        if (timerMinut == 10)
        {
            Debug.Log("GG");
        }

    }
    private void Start()
    {
        TextTimer.text = timerSecond.ToString() ;
    }
}
