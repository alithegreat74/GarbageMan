using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float _startValue;

    [SerializeField] private List<float> _modifiers;

    public void AddModifier(float modifier)=>_modifiers.Add(modifier);

    public float GetValue()
    {
        float value = _startValue;

        foreach (var modifier in _modifiers)
            value += modifier;

        return value;
    }
}
