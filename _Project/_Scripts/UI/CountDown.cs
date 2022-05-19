using System.Collections;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [Header("Countdown")]
    [SerializeField] private Canvas _canvasCountDown;
    [SerializeField] private TextMeshProUGUI _countDownText;
    private float _startCountDownAt = 3f;
    private float _countDownTime;
    public static event System.Action OnCountDownEnd;

    private IEnumerator Start()
    {
        _countDownTime = _startCountDownAt;
        do
        {
            _countDownTime -= 3f * Time.deltaTime;
            _countDownText.text = ((int)_countDownTime + 1).ToString();
            yield return null;
        } while (_countDownTime > 0);

        _countDownTime = 0;
        _countDownText.text = "0";
        _canvasCountDown.gameObject.SetActive(false);

        OnCountDownEnd?.Invoke();
    }
}
