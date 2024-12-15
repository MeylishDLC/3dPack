using System;
using TMPro;
using UnityEngine;

namespace Script
{
    public class CoinCounter: MonoBehaviour
    {
        private TMP_Text _text;
        private int _currentCoinAmount;
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = $"{_currentCoinAmount} MONEY";
            Coin.OnCoinCollected += UpdateCoinAmount;
        }
        private void OnDestroy()
        {
            Coin.OnCoinCollected -= UpdateCoinAmount;
        }
        private void UpdateCoinAmount(int amount)
        {
            _currentCoinAmount += amount;
            _text.text = $"{_currentCoinAmount} MONEY";
        }
    }
}