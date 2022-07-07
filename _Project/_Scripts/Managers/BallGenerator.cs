using UnityEngine;

public class BallGenerator : Singleton<BallGenerator>
{

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] public int _numberOfBalls = 0;


    private void OnEnable()
    {
        Score.OnScoreChanged += CheckScore;
        CanvasManager.OnStartGame += GenerateBall;
        GameOver.OnDestroyBall += DestroyBall;
    }
    private void OnDisable()
    {
        Score.OnScoreChanged -= CheckScore;
        CanvasManager.OnStartGame -= GenerateBall;
        GameOver.OnDestroyBall -= DestroyBall;
    }

    private void CheckScore(int score)
    {
        if (score % 50 == 0)
        {
            GenerateBall();
        }
    }

    private void GenerateBall()
    {
        GameObject ball = Instantiate(_ballPrefab);
        ball.transform.position = Vector2.zero;
        if (ball.TryGetComponent<BallBehaviour>(out var ballBehaviour))
        {
            // ballBehaviour.KickBallStart();
            _numberOfBalls++;
        }
    }

    public int DestroyBall(GameObject ball)
    {
        Destroy(ball);
        _numberOfBalls--;
        CameraShake.Instance?.ShakeCamera(5f);
        return _numberOfBalls;
    }
}
