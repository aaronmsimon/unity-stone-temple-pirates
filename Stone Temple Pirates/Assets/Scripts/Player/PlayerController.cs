using System.Runtime.InteropServices;
using UnityEditor.Callbacks;
using UnityEngine;

namespace STP.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private Vector2 movement;

        private Rigidbody rb;
        private PlayerControls playerControls;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void Update()
        {
            GetPlayerInput();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void GetPlayerInput()
        {
            movement = playerControls.Temples.Movement.ReadValue<Vector2>();
        }

        private void MovePlayer()
        {
            Vector3 targetPosition = movement * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + targetPosition);
        }
    }
}
