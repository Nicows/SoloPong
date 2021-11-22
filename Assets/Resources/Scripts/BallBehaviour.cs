using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbodyBall;
    private AudioSource hitSound;
    
    void Start()
    {
        GetBallComponents();
    }
    private void GetBallComponents()
    {
        rigidbodyBall = GetComponent<Rigidbody2D>();
        hitSound = GetComponent<AudioSource>();
    }
    public void KickBall()
    {
        float randomX = Random.Range(-1f, 1f);
        Vector2 counterKick = new Vector2(randomX, 1f);
        rigidbodyBall.AddForce(counterKick * PlayerMovement.kickForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        GetComponentInChildren<ParticleSystem>().Play();
        
        hitSound.pitch = Random.Range(0.8f, 1.2f);
        hitSound.Play();
    }

}
