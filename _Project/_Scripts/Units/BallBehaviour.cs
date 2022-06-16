using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    private Rigidbody2D _rigidbodyBall;
    private ParticleSystem _particleSystem;

    private void Start()
    {

    }

    private void OnEnable()
    {
        // CountDown.OnCountDownEnd += KickBallStart;
        // CanvasManager.OnStartGame += KickBallStart;
        _rigidbodyBall = GetComponent<Rigidbody2D>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void OnDisable()
    {
        // CountDown.OnCountDownEnd -= KickBallStart;
        // CanvasManager.OnStartGame -= KickBallStart;
    }

    private void Update()
    {
        // if (_rigidbodyBall.velocity.magnitude < 1)
        // {
        //     KickBallStart();
        // }
        //TODO des fois la vitesse de la balle est trop petite, on accélère la balle


        if (_rigidbodyBall.velocity.magnitude > PlayerMovement.kickForce)
        {
            _rigidbodyBall.velocity = _rigidbodyBall.velocity.normalized * PlayerMovement.kickForce;
        }



    }

    public void KickBallStart()
    {
        var direction = GetRandomXDirection() + Vector2.up;
        KickBall(direction);
    }

    public void WallCounterKick()
    {
        _rigidbodyBall.velocity = new Vector2(0, 0);
        Vector2 direction = GetRandomXDirection() + Vector2.down;
        KickBall(direction);
    }
    private Vector2 GetRandomXDirection() => new Vector2(Random.Range(-1f, 1f), 0f);
    private void KickBall(Vector2 direction) => _rigidbodyBall.AddForce(direction * PlayerMovement.kickForce, ForceMode2D.Impulse);

    private void OnCollisionEnter2D(Collision2D other)
    {
        Collision();
    }

    private void Collision()
    {
        _particleSystem?.Play();
        AudioSystem.Instance.PlaySound(_hitSound, 0.8f);
        CameraShake.Instance?.ShakeCamera(2f);
    }

}
