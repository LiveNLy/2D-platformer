using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinReleasing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollisionHandler collisionHandler) || collision.gameObject.TryGetComponent(out DeathTrigger deathTrigger))
        {
            CoinReleasing?.Invoke(this);
        }
    }
}