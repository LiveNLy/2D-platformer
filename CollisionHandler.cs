using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;

    public event Action CoinTaken;
    public event Action CoinIndicatorReset;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            CoinTaken?.Invoke();
        }
        else if (collision.gameObject.TryGetComponent(out DeathTrigger deathTrigger))
        {
            gameObject.transform.position = _startPosition;
            CoinIndicatorReset?.Invoke();
        }
    }
}
