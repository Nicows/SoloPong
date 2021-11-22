using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject panelGameOver;
    public PlayerMovement playerMovement;
    public Score score;
    public AudioSource soundButton;
    
    public void RestartGame()
    {
        PlaySoundButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMenu()
    {
        PlaySoundButton();
        SceneManager.LoadScene("Menu");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ball"){
            DisplayGameOver();
        }
    }
    private void DisplayGameOver()
    {
        score.SetHighScore();
        panelGameOver.SetActive(true);
        playerMovement.PlayerGameOver();
    }
    private void PlaySoundButton()
    {
        soundButton.pitch = Random.Range(0.8f, 1.2f);
        soundButton.Play();
    }
}
