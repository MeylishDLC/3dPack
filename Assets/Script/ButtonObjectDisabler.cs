using System;
using UnityEngine;

namespace Script
{
    public class ButtonObjectDisabler : MonoBehaviour
    {
        [SerializeField] private GameObject objectToDisable;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private GameObject objectToPutOnButton;
        private void OnTriggerEnter(Collider other)
        {
            if (CheckIfCanDisable(other))
            {
                objectToDisable.SetActive(false);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (CheckIfCanDisable(other))
            {
                objectToDisable.SetActive(true);
            }
        }

        private bool CheckIfCanDisable(Collider other)
        {
            if (((1 << other.gameObject.layer) & playerLayer.value) != 0)
            {
                return true;
            }
            return other.gameObject == objectToPutOnButton;
        }
    }
}
