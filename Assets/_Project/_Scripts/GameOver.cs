using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private AudioClip _soundButton;
    public static event System.Action OnGameOver;
    
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
        if(other.CompareTag("Ball"))
            DisplayGameOver();
    }
    private void DisplayGameOver()
    {
        OnGameOver?.Invoke();
        panelGameOver.SetActive(true);
    }
    private void PlaySoundButton()
    {
        // AudioSystem.Instance.PlaySound(_soundButton, 0.8f);
        AudioSystem.Instance.PlayClickButton();
    }
}
