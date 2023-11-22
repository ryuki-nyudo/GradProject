using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Time_src : MonoBehaviour
{
    private int hour;
    private int minute;
    private float seconds;
    private float oldSeconds;
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        hour = 0;
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        
        if(seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }

        if (minute >= 60f)
        {
            hour++;
            minute = minute - 60;
        }
        //値が変わった時だけテキストUIを更新
        if((int)seconds != (int)oldSeconds)
        {
            timerText.text = hour.ToString("00") + ":" + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
}
