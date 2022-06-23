using UnityEngine;

public class BallGenerator : Singleton<BallGenerator>
{

    [SerializeField] private GameObject _ballPrefab;
    public static int _numberOfBalls = 0;


    private void OnEnable()
    {
        Score.OnScoreChanged += CheckScore;
        CanvasManager.OnStartGame += GenerateBall;
    }
    private void OnDisable()
    {
        Score.OnScoreChanged -= CheckScore;
        CanvasManager.OnStartGame -= GenerateBall;
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
            ballBehaviour.KickBallStart();
            _numberOfBalls++;
        }
    }

    public static int DestroyBall(GameObject ball)
    {
        Destroy(ball);
        CameraShake.Instance?.ShakeCamera(5f);
        _numberOfBalls--;
        return _numberOfBalls;
    }
}
