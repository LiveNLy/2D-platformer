using UnityEngine;

public class OnDeathReseter : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private CoinIndicator _coinIndicator;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out DeathTrigger deathTrigger))
        {
            gameObject.transform.position = _startPosition;
            _coinIndicator.CoinsCountReset();
        }
    }
}