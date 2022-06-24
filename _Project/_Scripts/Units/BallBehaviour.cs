using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    private Rigidbody2D _rigidbodyBall;
    private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _rigidbodyBall = GetComponent<Rigidbody2D>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        _rigidbodyBall.velocity = _rigidbodyBall.velocity.normalized * PlayerMovement.KickForce;
    }

    public void KickBallStart()
    {
        var direction = GetRandomXDirection() + Vector2.up;
        KickBall(direction);
    }

    public void WallCounterKick()
    {
        _rigidbodyBall.velocity = Vector2.zero;
        var direction = GetRandomXDirection() + Vector2.down;
        KickBall(direction);
    }

    private Vector2 GetRandomXDirection() => new Vector2(Random.Range(-1f, 1f), 0f);

    private void KickBall(Vector2 direction) => _rigidbodyBall.AddForce(direction * PlayerMovement.KickForce, ForceMode2D.Impulse);

    private void OnCollisionEnter2D(Collision2D other)
    {
        _particleSystem?.Play();
        AudioSystem.Instance.PlaySound(_hitSound, 0.8f);
        CameraShake.Instance?.ShakeCamera(2f);
    }

}
