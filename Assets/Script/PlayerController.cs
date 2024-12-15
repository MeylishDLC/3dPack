using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")] 
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float turnSpeed = 200f;
        [SerializeField] private LayerMask layerMask;

        [Header("Jump Settings")] 
        [SerializeField] private float jumpPower = 5f;
        [SerializeField] private KeyCode jumpButton = KeyCode.Space;

        [SerializeField] private float fallThreshold = -10f;
        
        private Rigidbody _rb;
        private bool _isGrounded;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            HandleMovement();
            HandleJump();
            HandleFall();
        }
        private void HandleMovement()
        {
            var verticalInput = Input.GetAxis("Vertical");
            var moveDirection = transform.forward * (verticalInput * moveSpeed * Time.deltaTime);
            transform.position += moveDirection;

            var horizontalInput = Input.GetAxis("Horizontal");
            var turnAmount = horizontalInput * turnSpeed * Time.deltaTime;
            transform.Rotate(0, turnAmount, 0);
        }

        private void HandleJump()
        {
            if (Input.GetKeyDown(jumpButton) && _isGrounded)
            {
                _rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                _isGrounded = false;
            }
        }
        private void HandleFall()
        {
            if (transform.position.y < fallThreshold)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (((1 << other.gameObject.layer) & layerMask.value) != 0)
            {
                _isGrounded = true;
            }
        }
        private void OnCollisionExit(Collision other)
        {
            if (((1 << other.gameObject.layer) & layerMask.value) != 0)
            {
                _isGrounded = false;
            } 
        }
    }
}
