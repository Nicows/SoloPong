using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    private Rigidbody2D _rigidbodyBall;
    private ParticleSystem _particleSystem;
    
    void Start()
    {
        GetBallComponents();
    }
    private void GetBallComponents()
    {
        _rigidbodyBall = GetComponent<Rigidbody2D>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    public void KickBall()
    {
        float randomX = Random.Range(-1f, 1f);
        Vector2 counterKick = new Vector2(randomX, 1f);
        _rigidbodyBall.AddForce(counterKick * PlayerMovement.kickForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        _particleSystem.Play();
        AudioSystem.Instance.PlaySound(_hitSound, 0.8f);
    }

}
