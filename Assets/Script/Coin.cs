using System;
using UnityEngine;

namespace Script
{
    public class Coin: MonoBehaviour
    {
        public static event Action<int> OnCoinCollected;
        [SerializeField] private int coinValue;
        [SerializeField] private LayerMask playerLayer;

        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayer.value) != 0)
            {
                OnCoinCollected?.Invoke(coinValue);
                gameObject.SetActive(false);
            } 
        }
    }
}