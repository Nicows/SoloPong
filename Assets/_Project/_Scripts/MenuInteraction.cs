using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textHighScore; 
   
    private void Start() {
        DisplayHighScore();
    }
    public void StartGame()
    {
        AudioSystem.Instance.PlayClickButton();
        SceneManager.LoadScene("MainScene");
    }
    private void DisplayHighScore() => _textHighScore.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0).ToString()}";
}
