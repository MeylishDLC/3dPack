using System;
using UnityEngine;

namespace Script
{
    public class DangerZone: MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private GameObject attackObjectPrefab;
        [SerializeField] private float positionAbovePlayer = 5f;
        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayer.value) != 0)
            {
                var spawnPos = new Vector3(other.gameObject.transform.position.x,
                    other.gameObject.transform.position.y + positionAbovePlayer, other.gameObject.transform.position.z);
                Instantiate(attackObjectPrefab, spawnPos, Quaternion.identity);
            } 
        }
    }
}