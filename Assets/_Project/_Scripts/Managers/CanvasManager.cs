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

    private void PlaySoundButton() => AudioSystem.Instance.PlayClickButton();

    public void StartGame()
    {
        PlaySoundButton();
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
        ResumeGame();
        SceneManager.LoadScene("Menu");
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (!IsPlaying()) return;
        if (pauseStatus)
            PauseGame();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!IsPlaying()) return;
        if (!hasFocus)
            PauseGame();
    }
    private bool IsPlaying() => !_panelGameOver.gameObject.activeInHierarchy && !_canvasTouchToStart.gameObject.activeInHierarchy;
}
