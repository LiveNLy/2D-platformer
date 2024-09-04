using TMPro;
using UnityEngine;

public class CoinIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _updateRate;

    private int _numberOfTakenCoins = 0;

    private void Update()
    {
        _text.text = "coins: " + _numberOfTakenCoins;
    }

    public void CoinsCount()
    {
        _numberOfTakenCoins++;
    }

    public void CoinsCountReset()
    {
        _numberOfTakenCoins = 0;
    }
}
