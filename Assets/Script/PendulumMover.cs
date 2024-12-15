using UnityEngine;

namespace Script
{
    public class PendulumMover: MonoBehaviour
    {
        [SerializeField] private Transform pivotTransform;
        [SerializeField] private float maxAngle;
        [SerializeField] private float minAngle;
        [SerializeField] private float swingSpeed = 200f;

        private float _currentAngle;                    
        private float _direction = 1f;
        private void Start()
        {
            _currentAngle = minAngle;
        }
        private void Update()
        {
            _currentAngle += _direction * swingSpeed * Time.deltaTime;

            if (_currentAngle >= maxAngle)
            {
                _currentAngle = maxAngle;
                _direction = -1f;
            }
            else if (_currentAngle <= minAngle)
            {
                _currentAngle = minAngle;
                _direction = 1f;
            }

            pivotTransform.localRotation = Quaternion.Euler(0, 0, _currentAngle);
        }
    }
}