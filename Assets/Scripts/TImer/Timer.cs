using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timerMinut;
    public static float timerSecond;
    public GameObject win;
    public Text TextTimer;

    private void Update()
    {
        timerSecond += Time.deltaTime;
        var answer = string.Format("{0}:{1:00}", 
            timerMinut, 
            timerSecond);
        TextTimer.text = answer;
        if (timerSecond > 60)
        {
            Debug.Log(timerSecond);
            timerSecond = 0;
            timerMinut += 1;
        }
        if (timerMinut == 5)
        {
            win.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
            
        }

    }
    private void Start()
    {
        timerMinut = 0;
        timerSecond = 0;
}
}
