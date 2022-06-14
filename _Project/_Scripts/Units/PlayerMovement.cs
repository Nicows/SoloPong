using System.Collections;
using System.Collections.Generic;
using nicolaskohler;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rbPlayer;

    [Header("Movements")]
    public static bool PlayerCanMove = false;

    [Header("Kick")]
    [SerializeField] private AudioClip _kickSound;
    public static float kickForce { get; private set; } = 10f;

    private Transform _ballTransform;
    private float _maxKickForce = 35f;
    // [SerializeField] private ParticleSystem _particleSystem;
    //TODO: Add particle system to kick

    [Header("Inputs")]
    [SerializeField] private PlayerInput _playerInput;
    private InputAction _movementAction;
    [SerializeField] private bool _autoMove;

    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        _movementAction = _playerInput.actions["Move"];
        kickForce = 10f;
        _ballTransform = GameObject.FindGameObjectWithTag("Ball").transform;
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
        if (_autoMove) AutoMove();
        InputMovements();
    }

    private void AutoMove()
    {
        PlayerCanMove = false;
        var direction = new Vector2(_ballTransform.position.x, transform.position.y);
        transform.position = direction;
    }

    private void InputMovements()
    {
        if (!PlayerCanMove) return;

        Vector2 direction;
        Vector2 touchPosition = (SystemInfo.deviceType == DeviceType.Handheld)
            ? Helpers.Camera.ScreenToWorldPoint(Input.touches[0].position)
            : Helpers.Camera.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(touchPosition.x, transform.position.y);
        transform.position = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
            KickBall(collision.transform);
    }
    private void KickBall(Transform ball)
    {
        AudioSystem.Instance?.PlaySound(_kickSound, 0.8f);
        // _particleSystem?.Play();

        if (ball.TryGetComponent<Rigidbody2D>(out Rigidbody2D ballRb))
        {
            ballRb.AddForce(ballRb.velocity.normalized + kickForce * Vector2.up, ForceMode2D.Impulse);

            if (kickForce < _maxKickForce)
                kickForce += 0.2f;
        }
    }
    private void PlayerGameOver()
    {
        PlayerCanMove = false;
        _rbPlayer.velocity = Vector2.zero;
    }
}
