using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public float startValue;

    [SerializeField] private List<float> _modifiers;

    public void AddModifier(float modifier)=>_modifiers.Add(modifier);
    public void RemoveModifier(float modifier) => _modifiers.Remove(modifier);
    public float GetValue()
    {
        float value = startValue;

        foreach (var modifier in _modifiers)
            value += modifier;

        return value;
    }
}
