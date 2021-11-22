using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTouch : MonoBehaviour
{
    public CameraShake cameraShake;
    private Score score;

    void Start()
    {
        score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball") BallBouncing();
        if (collision.otherCollider.tag == "Enemy")
        {
            score.AddScore();
            CounterKick(collision.transform);
        }
    }
    private void CounterKick(Transform ball)
    {
        float randomX = Random.Range(0f, -1f);
        float randomY = Random.Range(0f, -1f);
        Vector2 counterKick = new Vector2(randomX, randomY);
        ball.GetComponent<Rigidbody2D>().AddForce(counterKick * PlayerMovement.kickForce , ForceMode2D.Impulse);
    }
    private void BallBouncing()
    {
        cameraShake.ShakeCamera(2f);
    }
}
