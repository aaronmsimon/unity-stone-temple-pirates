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

        private float movement;
        private bool isJumping;
        private Vector3 fallSpeed;
        private Vector3 lowJumpSpeed;

        private Rigidbody rb;
        private PlayerControls playerControls;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerControls = new PlayerControls();
        }

        private void Start()
        {
            fallSpeed = Vector3.up * Physics.gravity.y * (fallMultiplier - 1);
            lowJumpSpeed = Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1);
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
            GetMoveInput();
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandleJumping();
        }

        private void GetMoveInput()
        {
            movement = playerControls.Temples.Movement.ReadValue<float>();
        }

        private void HandleMovement()
        {
            Vector3 targetPosition = Vector3.right * movement * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + targetPosition);
        }

        private void JumpStart()
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
            isJumping = true;
        }

        private void JumpCancel()
        {
            isJumping = false;
        }

        private void HandleJumping()
        {
            if (rb.velocity.y < 0)
            {
                rb.AddForce(fallSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
            else if (rb.velocity.y > 0 && !isJumping)
            {
                rb.AddForce(lowJumpSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }
}
