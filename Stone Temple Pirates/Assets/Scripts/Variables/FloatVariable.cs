using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Variable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float value;
    public event Action<float> OnValueChanged;

    public float Value => value;

    public void SetValue(float newValue)
    {
        value = newValue;
        OnValueChanged?.Invoke(value);
    }
}
