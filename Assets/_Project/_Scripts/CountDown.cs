using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [Header("Countdown")]
    [SerializeField] private GameObject _panelCountDown;
    [SerializeField] private TextMeshProUGUI _countDownText;
    private float startCountDownAt = 3f;
    private float countDownTime;
    public static event System.Action OnCountDownEnd;

    private IEnumerator Start()
    {
        countDownTime = startCountDownAt;
        do
        {
            countDownTime -= 3f * Time.deltaTime;
            _countDownText.text = ((int)countDownTime + 1).ToString();
            yield return null;
        } while (countDownTime > 0);

        countDownTime = 0;
        _countDownText.text = "0";
        _panelCountDown.SetActive(false);

        OnCountDownEnd?.Invoke();
    }
}
