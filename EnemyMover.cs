using UnityEngine;

[RequireComponent(typeof(SpriteFliper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;

    private SpriteFliper _fliper;
    private int _numberOfMovePoint = 0;
    private bool _flipped = true;

    private void Start()
    {
        _fliper = GetComponent<SpriteFliper>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _movePoints[_numberOfMovePoint].position, _speed * Time.deltaTime);

        if (transform.position == _movePoints[_numberOfMovePoint].position)
            _numberOfMovePoint = (++_numberOfMovePoint) % _movePoints.Length;

        if (_numberOfMovePoint == 0 && !_flipped)
        {
            _fliper.Flip();
            _flipped = !_flipped;
        } 
        else if (_numberOfMovePoint == 1 && _flipped)
        {
            _fliper.Flip();
            _flipped = !_flipped;
        }
    }
}