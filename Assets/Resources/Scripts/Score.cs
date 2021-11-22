using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;
    public TMP_Text textScore;
    public Animator animator;

    void Start()
    {
        ResetScore();
    }
    private void ResetScore()
    {
        score = 0;
        UpdateTextScore();
    }
    public void AddScore()
    {
        score++;
        UpdateTextScore();
    }
    private void UpdateTextScore()
    {
        textScore.text = score.ToString();
        animator.Play("ScoreAnim");
    }
    public int GetHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        return highScore;
    }
    public void SetHighScore()
    {
        int previousHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > previousHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
