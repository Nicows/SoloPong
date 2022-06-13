using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallTouch : MonoBehaviour
{
    public static event System.Action OnSideWallTouch;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            OnSideWallTouch?.Invoke();
        }
    }
}
