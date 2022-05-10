using UnityEngine;

public class WallTouch : MonoBehaviour
{
    public static event System.Action OnWallTouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Enemy"))
        {
            OnWallTouch?.Invoke();
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
}
