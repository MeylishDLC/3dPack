using System;
using TMPro;
using UnityEngine;

namespace Script
{
    public class WalletPanel: MonoBehaviour
    {
        private TMP_Text _walletBalanceText;
        private int _currentWalletBalance;
        private void Awake()
        {
            _walletBalanceText = GetComponent<TMP_Text>();
            _walletBalanceText.text = $"БАЛАНС {_currentWalletBalance}";
            Coin.OnCoinCollected += UpdateCoinAmount;
        }
        private void OnDestroy()
        {
            Coin.OnCoinCollected -= UpdateCoinAmount;
        }
        private void UpdateCoinAmount(int amount)
        {
            _currentWalletBalance += amount;
            _walletBalanceText.text = $"БАЛАНС {_currentWalletBalance}";
        }
    }
}