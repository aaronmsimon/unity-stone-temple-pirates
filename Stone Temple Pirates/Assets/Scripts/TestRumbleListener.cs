using UnityEngine;

public class TestRumbleListener : MonoBehaviour
{
    [SerializeField] private FloatVariable rumbleLeft;

    private void OnEnable() {
        rumbleLeft.OnValueChanged += DisplayNewValue;
    }

    private void OnDisable() {
        rumbleLeft.OnValueChanged -= DisplayNewValue;
    }

    private void DisplayNewValue(float newValue) {
        Debug.Log($"Rumble Left: {newValue}");
    }
}
