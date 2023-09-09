using UnityEngine;

namespace STP.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float jumpDecentMultiplier = 2f;

        private Vector2 movement;
        private bool isJumping;
        private bool hasJumpDescent;

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
            playerControls.Temples.Jump.canceled += ctx => JumpEnd();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void Update()
        {
            GetPlayerInput();
                Debug.Log(Physics.gravity);
        }

        private void FixedUpdate()
        {
            MovePlayer();
            HandleJumpDescent();
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            hasJumpDescent = false;
        }

        private void JumpEnd()
        {
            isJumping = false;
        }

        private void HandleJumpDescent()
        {
            if (rb.velocity.y < 0 && !hasJumpDescent)
            {
                rb.AddForce(Vector3.down * jumpForce * jumpDecentMultiplier, ForceMode.Impulse);
                hasJumpDescent = true;
            }
        }
    }
}
