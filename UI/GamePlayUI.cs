using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GamePlayUI : MonoBehaviour
{
    public TextMeshProUGUI TimerBackgroundText;
    public TextMeshProUGUI TimerFirstDigit;
    public TextMeshProUGUI TimerSecondDigit;
    public TextMeshProUGUI TimerThirdDigit;
    public TextMeshProUGUI TimerFourthDigit;
    public float Timer;
    private float flashTimer;
    public float FlashDuration = 0.5F;
    void Start()
    {
        ResetTimer();
    }

   
    void Update()
    {
        Timer = GameManager.instance.gameStates.Gametimer;
        UpdateTimerDisplay(Timer);

        if(GameManager.instance.gameStates.Gametimer == 600)
        {
            TimerFlash();
        }
    }
    public void ResetTimer()
    {
      Timer = GameManager.instance.gameStates.Gametimer;
    }
    public void UpdateTimerDisplay(float time)
    {
       float minutes = Mathf.FloorToInt(time/ 60);
       float seconds = Mathf.FloorToInt(time % 60);
       
       string currentTime = string.Format("{00:00}{1:00}", minutes,seconds);
       TimerFirstDigit.text = currentTime[0].ToString();
       TimerSecondDigit.text = currentTime[1].ToString();
       TimerThirdDigit.text= currentTime[2].ToString();
       TimerFourthDigit.text= currentTime[3].ToString();
    }
    public void TimerFlash()
    {
       if(flashTimer <=0)
       {
        flashTimer = FlashDuration;
       }
       else if(flashTimer >= FlashDuration / 2)
       {
        flashTimer -= Time.deltaTime;
        SetTextDisplay(false);
       }
       else
       {
        flashTimer -= Time.deltaTime;
        SetTextDisplay(true);
       }

    }
      public void SetTextDisplay(bool State)
       {
         TimerFirstDigit.enabled = State;
         TimerSecondDigit.enabled = State;
         TimerThirdDigit.enabled = State;
         TimerFourthDigit.enabled = State;
       }
}
