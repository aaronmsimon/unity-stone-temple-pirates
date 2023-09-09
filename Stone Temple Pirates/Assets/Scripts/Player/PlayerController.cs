using UnityEngine;

namespace STP.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpVelocity = 5f;
        [SerializeField] private float fallMultiplier = 2.5f;
        [SerializeField] private float lowJumpMultiplier = 2f;

        private Vector2 movement;
        private bool isJumping;

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
            playerControls.Temples.Jump.started += ctx => JumpStart();
            playerControls.Temples.Jump.canceled += ctx => JumpCancel();
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
            JumpPlayer();
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

        private void JumpStart()
        {
            rb.velocity = Vector3.up * jumpVelocity;
            isJumping = true;
        }

        private void JumpCancel()
        {
            isJumping = false;
        }

        private void JumpPlayer()
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            }
            else if (rb.velocity.y > 0 && !isJumping)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
        }
    }
}
