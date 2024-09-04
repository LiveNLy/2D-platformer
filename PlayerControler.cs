using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private bool _canJump = true;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private CoinIndicator _coinIndicator;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool flipped = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);

        _animator.SetBool("Running", IsCharacterMoving());

        if (direction > 0 && !flipped)
            Flip();
        else if (direction < 0 && flipped)
            Flip();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _canJump == true)
        {
            _animator.SetTrigger("Jumping");
            _rigidbody.velocity = _jumpPower * Vector2.up;
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        flipped = !flipped;
    }

    private bool IsCharacterMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return true;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            gameObject.transform.position = _startPosition;
            _coinIndicator.CoinsCountReset();
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