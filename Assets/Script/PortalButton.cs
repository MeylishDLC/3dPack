using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class PortalButton: MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayerMask;
        [SerializeField] private int sceneToTeleportIndex;

        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayerMask.value) != 0)
            {
                SceneManager.LoadScene(sceneToTeleportIndex);
            } 
        }
    }
}