using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static event System.Action OnGameOver;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball"))
            OnGameOver?.Invoke();
    }
}
