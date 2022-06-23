using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private Animator _animator;

    public static event System.Action<int> OnScoreChanged;
    private int _score;

    private void OnEnable()
    {
        ResetScore();
        WallTouch.OnWallTouch += AddScore;
        GameOver.OnGameOver += SetHighScore;
    }

    private void OnDisable()
    {
        WallTouch.OnWallTouch -= AddScore;
        GameOver.OnGameOver -= SetHighScore;
    }

    private void ResetScore()
    {
        _score = 0;
        _textScore.text = _score.ToString();
    }

    public void AddScore()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
        _textScore.text = _score.ToString();
        _animator.Play("ScoreAnim");
    }

    public int GetHighScore() => PlayerPrefs.GetInt("HighScore", 0);

    public void SetHighScore()
    {
        int previousHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (_score > previousHighScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }


}
