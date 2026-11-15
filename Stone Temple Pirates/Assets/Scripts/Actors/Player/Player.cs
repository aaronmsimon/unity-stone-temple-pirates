using UnityEngine;
using STP.Input;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private GameObject aimSprite;
    [SerializeField] private StoneSO currentStone;
    [SerializeField] private StoneEventChannelSO stoneEventChannel;
    [SerializeField] private Vector3 aimStartOffset;

    private float moveInput;
    private Vector2 aimInput;

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
        inputReader.stonePowerAimEvent += OnStonePowerAim;
    }

    private void OnDisable() {
        inputReader.moveCharacterEvent -= OnMove;
        inputReader.stonePowerActivatedEvent -= OnStonePowerActivated;
        inputReader.stonePowerAimEvent -= OnStonePowerAim;
    }

    private void Update() {
        Aim();
    }

    private void FixedUpdate() {
        Move();
    }

    private void OnMove(float moveInput) {
        this.moveInput = moveInput;
    }

    private void OnStonePowerActivated(bool active) {
        aimSprite.GetComponent<SpriteRenderer>().enabled = active;

        if (active) {
            // Ston'e own effect
            currentStone.Activate(this);
            // World broadcast
            stoneEventChannel.RaiseActivated(currentStone);
        }
    }

    private void OnStonePowerAim(Vector2 aimInput) {
        this.aimInput = aimInput;
    }

    private void Move() {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    private void Aim() {
        float zPos = transform.position.z;
        aimSprite.transform.position = transform.position + aimStartOffset + new Vector3(aimInput.x, aimInput.y, zPos);
    }
}
