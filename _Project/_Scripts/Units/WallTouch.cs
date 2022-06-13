using UnityEngine;

public class WallTouch : MonoBehaviour
{
    public static event System.Action OnWallTouch;
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            OnWallTouch?.Invoke();
            if (collision.transform.TryGetComponent<BallBehaviour>(out BallBehaviour ballBehaviour))
            {
                ballBehaviour.WallCounterKick();
            }
        }
    }
}
