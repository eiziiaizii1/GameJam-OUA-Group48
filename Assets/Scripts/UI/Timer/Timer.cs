using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime > 90)
            {
                timerText.color = Color.white;
            }else if ((remainingTime < 90) && (remainingTime > 60))
            {
                timerText.color = Color.magenta;
            }else if ((remainingTime < 60) && (remainingTime > 30))
            {
                timerText.color = Color.red;
            }
        }
        else if(remainingTime<0)

        {
            remainingTime = 0;
        }
       //Dakika ve saniyenin 60 lı periyotlar halinde azalması 
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
