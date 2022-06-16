using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static event System.Action OnGameOver;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            _particleSystem.transform.position = other.transform.position;
            _particleSystem.Play();
            BallGenerator.DestroyBall(other.gameObject);
            if (BallGenerator._numberOfBalls <= 0)
            {
                OnGameOver?.Invoke();
            }
        }
    }
}
