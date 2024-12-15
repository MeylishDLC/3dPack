using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class ButtonMessageShower : MonoBehaviour
    {
        [SerializeField] private Image messagePanel;
        [SerializeField] private LayerMask playerLayerMask;
        private void Start()
        {
            messagePanel.gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayerMask.value) != 0)
            {
                messagePanel.gameObject.SetActive(true);
            } 
        }

        private void OnTriggerExit(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayerMask.value) != 0)
            {
                messagePanel.gameObject.SetActive(false);
            } 
        }
    }
}
