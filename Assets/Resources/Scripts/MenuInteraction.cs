using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInteraction : MonoBehaviour
{
    public TMP_Text textHighScore; 
    public AudioSource soundButton;
   
    private void Start() {
        DisplayHighScore();
    }
    public void StartGame()
    {
        PlaySoundButton();
        SceneManager.LoadScene("MainScene");
    }
    public void DisplayHighScore()
    {
        textHighScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void PlaySoundButton()
    {
        soundButton.pitch = Random.Range(0.8f, 1.2f);
        soundButton.Play();
    }
}
