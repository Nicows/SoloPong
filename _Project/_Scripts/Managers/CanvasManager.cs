using nicolaskohler;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas _panelPause;
    [SerializeField] private Canvas _panelGameOver;
    [SerializeField] private Canvas _canvasTouchToStart;
    static public bool IsPaused = false;

    public static event System.Action OnStartGame;

    private void OnEnable()
    {
        GameOver.OnGameOver += DisplayGameOver;
    }
    private void OnDisable()
    {
        GameOver.OnGameOver -= DisplayGameOver;
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
        _canvasTouchToStart.gameObject.SetActive(false);
        PlayerMovement.PlayerCanMove = true;
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
        IsPaused = true;
        PlayerMovement.PlayerCanMove = false;
    }
    public void ResumeGame()
    {
        PlaySoundButton();
        _panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        PlayerMovement.PlayerCanMove = true;
    }
    public void ReturnToMenu()
    {
        PlaySoundButton();
        SceneManager.LoadScene("Menu");
    }

    private void PlaySoundButton() => AudioSystem.Instance.PlayClickButton();
}
