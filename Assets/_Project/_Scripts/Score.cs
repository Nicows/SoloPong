using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int _score;
    public TextMeshProUGUI textScore;
    public Animator animator;

    private void OnEnable() {
        ResetScore();
        WallTouch.OnWallTouch += AddScore;
        GameOver.OnGameOver += SetHighScore;
    }
    private void OnDisable() {
        WallTouch.OnWallTouch -= AddScore;
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
        textScore.text = _score.ToString();
        animator.Play("ScoreAnim");
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