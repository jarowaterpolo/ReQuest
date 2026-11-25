using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Scriptable Objects/Resource")]
public class Resource : ScriptableObject
{
    [SerializeField]
    private int initialValue;

    private int _value;
    public event Action<int> onValueChanged;
    public int value
    {
        set
        {
            if (_value != value)
            {
                _value = value;
                onValueChanged?.Invoke(value);
            }
        }
        get => _value;
    }

    [SerializeField]
    private int conversionValue;
    public int ConversionValue => conversionValue;

    private void OnEnable()
    {
        ResetValue();
    }

    public void ResetValue()
    {
        value = initialValue;
    }
}
