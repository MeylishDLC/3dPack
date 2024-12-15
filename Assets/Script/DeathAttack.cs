using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class DeathAttack: MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayer.value) != 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
        }
    }
}