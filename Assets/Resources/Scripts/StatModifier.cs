using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModType
{
    Flat, Percent
}

public class StatModifier
{
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Priority;

    public StatModifier(float aValue, StatModType aType, int aPrio)
    {
        Value = aValue;
        Type = aType;
        Priority = aPrio;
    }

    public StatModifier(float value, StatModType type) : this(value, type, (int)type) { }
}
