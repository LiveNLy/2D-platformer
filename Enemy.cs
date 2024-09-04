using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;

    private int _numberOfMovePoint = 0;
    private bool flipped = true;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _movePoints[_numberOfMovePoint].position, _speed * Time.deltaTime);

        if (transform.position == _movePoints[_numberOfMovePoint].position)
            _numberOfMovePoint = (++_numberOfMovePoint) % _movePoints.Length;

        if (_numberOfMovePoint == 0 && !flipped)
        {
            Flip();
        } 
        else if (_numberOfMovePoint == 1 && flipped)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        flipped = !flipped;
    }
}