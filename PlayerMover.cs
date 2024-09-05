using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteFliper))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Running = nameof(Running);

    [SerializeField] private float _moveSpeed;

    private Animator _animator;
    private SpriteFliper _fliper;
    private bool _flipped = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _fliper = GetComponent<SpriteFliper>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);

        _animator.SetBool(Running, IsCharacterMoving());

        if (direction > 0 && !_flipped)
        {
            _fliper.Flip();
            _flipped = !_flipped;
        }
        else if (direction < 0 && _flipped)
        {
            _fliper.Flip();
            _flipped = !_flipped;
        }
    }

    private bool IsCharacterMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return true;
        else
            return false;
    }
}
