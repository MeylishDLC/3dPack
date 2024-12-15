using System;
using UnityEngine;

namespace Script
{
    public class HoleButton: MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayer.value) != 0)
            {
                if(other.gameObject.TryGetComponent<Collider>(out var col))
                {
                    col.enabled = false;
                }
            } 
        }
    }
}