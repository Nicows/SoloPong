using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static event System.Action OnGameOver;
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
        var ballsRemaining = BallGenerator.DestroyBall(ballTransform.gameObject);
        if (ballsRemaining <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
}
