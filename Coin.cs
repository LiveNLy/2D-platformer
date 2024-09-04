using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] CoinSpawner _spawner;
    [SerializeField] CoinIndicator _indicator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerControler player))
        {
            _indicator.CoinsCount();
            _spawner.ReleaseCoin(this);
        }
        else if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _spawner.ReleaseCoin(this);
        }
    }
}