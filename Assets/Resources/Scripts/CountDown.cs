using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public BallBehaviour ball;
    public GameObject panelCountDown;
    [Header("Countdown")]
    public TMP_Text textCountDown;
    private float startCountDownAt = 3f;
    private bool countdownEnable = false;
    private float countDownTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        CountdownEnable();
    }
    private void CountdownEnable()
    {
        if (countdownEnable)
        {
            if (countDownTime > 0)
            {
                countDownTime -= 3f * Time.deltaTime;
                textCountDown.text = ((int) countDownTime + 1).ToString();
            } else if(countDownTime <= 0){
                StopCountdown();
                ball.KickBall();
            }
        }
    }
    private void StartCountdown()
    {
        countDownTime = startCountDownAt;
        countdownEnable = true;
    }
    private void StopCountdown()
    {
        countdownEnable = false;
        countDownTime = 0;
        textCountDown.text = "0";
        panelCountDown.SetActive(false);
    }
}
