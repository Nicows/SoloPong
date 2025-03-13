using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static event System.Action OnGameOver;
    public delegate int BallCollision(GameObject ball);
    public static event BallCollision OnDestroyBall;
    [SerializeField] private ParticleSystem _explosionParticles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            DestroyBall(other.gameObject);
        }
    }

    private void DestroyBall(GameObject ballTransform)
    {
        _explosionParticles.transform.position = ballTransform.transform.position;
        _explosionParticles.Play();
        var ballsRemaining = OnDestroyBall?.Invoke(ballTransform);
        Debug.Log($"Balls remaining: {ballsRemaining}");
        if (ballsRemaining <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
}
