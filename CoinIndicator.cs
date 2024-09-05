using TMPro;
using UnityEngine;

public class CoinIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _updateRate;

    private int _numberOfTakenCoins = 0;

    public void CoinsCount()
    {
        _numberOfTakenCoins++;
        _text.text = "coins: " + _numberOfTakenCoins;
    }

    public void CoinsCountReset()
    {
        _numberOfTakenCoins = 0;
        _text.text = "coins: " + _numberOfTakenCoins;
    }
}
