using System;
using System.Collections;
using UnityEngine;

namespace Script
{
    public class MessagePanel: MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(true);
        }
        private void Update()
        {
            if (Input.anyKey)
            {
                gameObject.SetActive(false);
            }
        }
    }
}