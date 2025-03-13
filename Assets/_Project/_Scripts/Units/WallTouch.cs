using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTouch : MonoBehaviour
{
    public static event System.Action OnWallTouch;
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Ball")) return;
        OnWallTouch?.Invoke();

        if (!gameObject.CompareTag("CounterWall")) return;
        if (collision.transform.TryGetComponent<BallBehaviour>(out BallBehaviour ballBehaviour))
            ballBehaviour.WallCounterKick();
    }

    public IEnumerator WaitBeforeDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        var animator = GetComponentInParent<Animator>();
        animator.SetTrigger("Destroy");
        yield return new WaitForSeconds(0.5f);
        Destroy(transform.parent.gameObject);
    }
}
