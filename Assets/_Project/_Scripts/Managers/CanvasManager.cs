using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas _panelPause;
    [SerializeField] private Canvas _panelGameOver;

    private void OnEnable() {
        GameOver.OnGameOver += DisplayGameOver;
    }
    private void OnDisable() {
        GameOver.OnGameOver -= DisplayGameOver;
    }
    
    public void RestartGame()
    {
        PlaySoundButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DisplayGameOver()
    {
        _panelGameOver.gameObject.SetActive(true);
    }
    
    public void PauseGame()
    {
        PlaySoundButton();
        _panelPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        PlaySoundButton();
        _panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToMenu()
    {
        PlaySoundButton();
        SceneManager.LoadScene("Menu");
    }

    private void PlaySoundButton() => AudioSystem.Instance.PlayClickButton();
}
