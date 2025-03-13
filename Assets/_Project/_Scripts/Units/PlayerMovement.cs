using NicolasKohler;
using NicolasKohler.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movements")]
    private Rigidbody2D _rbPlayer;
    public static bool PlayerCanMove = false;

    [Header("Kick")]
    [SerializeField] private AudioClip _kickSound;
    public static float KickForce { get; private set; } = 10f;
    private float _maxKickForce = 30f;

    [Header("Inputs")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private bool _autoMove;
    private InputAction _movementAction;

    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        _movementAction = _playerInput.actions["Move"];
        KickForce = 10f;
    }

    private void OnEnable()
    {
        GameOver.OnGameOver += PlayerGameOver;
    }
    private void OnDisable()
    {
        GameOver.OnGameOver -= PlayerGameOver;
    }
    private void Update()
    {
        // if (_autoMove) AutoMove();
        InputMovements();
    }

    // private void AutoMove()
    // {
    //     PlayerCanMove = false;
    //     var direction = new Vector2(_ballTransform.position.x, transform.position.y);
    //     transform.position = direction;
    // }

    private void InputMovements()
    {
        if (Helpers.IsOverUi()) return;
        if (!PlayerCanMove) return;

        var direction = TouchPosition();
        direction.y = transform.position.y;
        transform.position = direction;

        Vector2 TouchPosition()
        {
            return (SystemInfo.deviceType == DeviceType.Handheld)
                ? Helpers.Camera.ScreenToWorldPoint(Input.touches[0].position)
                : Helpers.Camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
            KickBall(collision.transform);
    }

    private void KickBall(Transform ball)
    {
        AudioSystem.Instance?.PlaySound(_kickSound, 0.8f);

        ball.TryGetComponent<Rigidbody2D>(out Rigidbody2D ballRb);
        ballRb.AddForce(KickForce * Vector2.up, ForceMode2D.Impulse);

        if (KickForce < _maxKickForce)
            KickForce += 0.2f;
    }

    private void PlayerGameOver()
    {
        PlayerCanMove = false;
        _rbPlayer.velocity = Vector2.zero;
    }
}
