using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rbPlayer;

    [Header ("Movements")]
    [SerializeField] private float _moveSpeed = 20f;
    private bool _playerCanMove = true;

    [Header ("Kick")]
    public static float kickForce = 5f;
    private float _maxKickForce = 8f;
    [SerializeField] private AudioClip _kickSound;
    // [SerializeField] private ParticleSystem _particleSystem;


    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        GameOver.OnGameOver += PlayerGameOver;
    }
    private void OnDisable() {
        GameOver.OnGameOver -= PlayerGameOver;
    }
    private void Update()
    {
        InputMovements();
    }

    private void InputMovements()
    {
        if(_playerCanMove){
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0f);
            _rbPlayer.velocity = direction * _moveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball")) 
            KickBall(collision.transform);
    }
    private void KickBall(Transform ball)
    {
        CameraShake.Instance.ShakeCamera(2f);
        AudioSystem.Instance.PlaySound(_kickSound, 0.8f);
        // _particleSystem?.Play();
        
        if(ball.TryGetComponent<Rigidbody2D>(out Rigidbody2D ballRb))
        {
            ballRb.AddForce(kickForce * Vector2.up, ForceMode2D.Impulse);

            if(kickForce < _maxKickForce)
                kickForce += 0.1f;
        }
    }
    private void PlayerGameOver()
    {
        _playerCanMove = false;
        _rbPlayer.velocity = Vector2.zero;
    }
}
