using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private Animator _animator;
    private int _score;

    private void OnEnable()
    {
        ResetScore();
        WallTouch.OnWallTouch += AddScore;
        SideWallTouch.OnSideWallTouch += AddScore;
        GameOver.OnGameOver += SetHighScore;
    }
    private void OnDisable()
    {
        WallTouch.OnWallTouch -= AddScore;
        SideWallTouch.OnSideWallTouch -= AddScore;
        GameOver.OnGameOver -= SetHighScore;
    }
    private void ResetScore()
    {
        _score = 0;
        UpdateTextScore();
    }
    public void AddScore()
    {
        _score++;
        UpdateTextScore();
    }
    private void UpdateTextScore()
    {
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
}
