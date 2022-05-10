using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private AudioClip _clickSound;
    
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
        AudioSystem.Instance.PlaySound(_clickSound, 0.8f);
    }
}
