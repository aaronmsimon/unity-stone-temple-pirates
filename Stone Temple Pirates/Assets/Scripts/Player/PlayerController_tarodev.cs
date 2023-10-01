using UnityEngine;

namespace tarodev
{
    public class PlayerController_tarodev : MonoBehaviour
    {
        [Header("Walking")]
         [SerializeField] private float acceleration = 90;
        [SerializeField] private float moveClamp = 13;
        [SerializeField] private float deceleration = 60f;
        // [SerializeField] private float apexBonus = 2;

        private Vector3 velocity;
        private float velX;

        private Vector3 lastPos;
        private float moveInput;

        private PlayerControls playerControls;

        private void Awake()
        {
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
            velocity = (transform.position - lastPos) / Time.deltaTime;
            lastPos = transform.position;

            GetMoveInput();
            CalculateWalk();
            MoveCharacter();
        }

        private void GetMoveInput()
        {
            moveInput = playerControls.Temples.Movement.ReadValue<float>();
        }

        private void CalculateWalk() {
            if (moveInput != 0)
            {
                // Set horizontal move speed
                velX += moveInput * acceleration * Time.deltaTime;

                // clamped by max frame movement
                velX = Mathf.Clamp(velX, -moveClamp, moveClamp);

                // Apply bonus at the apex of a jump
                // var apexBonus = Mathf.Sign(Input.X) * _apexBonus * _apexPoint;
                // _currentHorizontalSpeed += apexBonus * Time.deltaTime;
            }
            else
            {
                // No input. Let's slow the character down
                velX = Mathf.MoveTowards(velX, 0f, deceleration * Time.deltaTime);
            }

            // if (_currentHorizontalSpeed > 0 && _colRight || _currentHorizontalSpeed < 0 && _colLeft) {
            //     // Don't walk through walls
            //     _currentHorizontalSpeed = 0;
            // }
        }

        private void MoveCharacter() {
            Vector3 newPos = new Vector3(velX, 0f);
            transform.position += newPos * Time.deltaTime;
        }
    }
}