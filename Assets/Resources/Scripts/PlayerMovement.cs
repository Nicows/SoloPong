using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CameraShake cameraShake;
    private Rigidbody2D rbPlayer;

    [Header ("Movements")]
    private float moveSpeed = 20f;
    private bool playerCanMove = true;

    [Header ("Kick")]
    public static float kickForce = 5f;
    private float maxKickForce = 8f;


    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputMovements();
    }

    private void InputMovements()
    {
        if(playerCanMove){
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0f);
            rbPlayer.velocity = direction * moveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball") KickBall(collision.transform);
    }
    private void KickBall(Transform ball)
    {
        cameraShake.ShakeCamera(2f);
        // kickSound.pitch = Random.Range(0.8f, 1.2f);
        // kickSound.Play();
        // particleKick.Play();

        // Vector3 attackDir = (UtilsClass.GetMouseWorldPosition() - GetPosition()).normalized;
        // Vector3 targetPosition = GetPosition() + attackDir * attackOffset;
        ball.GetComponent<Rigidbody2D>().AddForce(kickForce * Vector2.up, ForceMode2D.Impulse);
        if(kickForce < maxKickForce)
            kickForce += 0.1f;
    }
    public void PlayerGameOver()
    {
        playerCanMove = false;
        rbPlayer.velocity = Vector2.zero;
    }
}
