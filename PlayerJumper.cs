using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerJumper : MonoBehaviour
{
    private const string Jumping = nameof(Jumping);

    [SerializeField] private bool _canJump = true;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _canJump == true)
        {
            _animator.SetTrigger(Jumping);
            _rigidbody.velocity = _jumpPower * Vector2.up;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground platform))
            _canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground platform))
            _canJump = false;
    }
}
