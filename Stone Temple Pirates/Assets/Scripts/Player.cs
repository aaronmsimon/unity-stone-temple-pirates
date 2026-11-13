using UnityEngine;
using STP.Input;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private GameObject aimSprite;

    private float moveInput;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        inputReader.EnableTempleInput();
    }

    private void OnEnable() {
        inputReader.moveCharacterEvent += OnMove;
        inputReader.stonePowerActivatedEvent += OnStonePowerActivated;
    }

    private void OnDisable() {
        inputReader.moveCharacterEvent -= OnMove;
        inputReader.stonePowerActivatedEvent -= OnStonePowerActivated;
    }

    private void FixedUpdate() {
        Move();
    }

    private void OnMove(float moveInput) {
        this.moveInput = moveInput;
    }

    private void OnStonePowerActivated(bool active) {
        aimSprite.SetActive(active);
    }

    private void Move() {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
}
