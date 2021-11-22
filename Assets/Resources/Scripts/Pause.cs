using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panelPause;
    public AudioSource soundButton;
    
    public void PauseGame()
    {
        PlaySoundButton();
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        PlaySoundButton();
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToMenu()
    {
        PlaySoundButton();
        SceneManager.LoadScene("Menu");
    }
    private void PlaySoundButton()
    {
        soundButton.pitch = Random.Range(0.8f, 1.2f);
        soundButton.Play();
    }
}
