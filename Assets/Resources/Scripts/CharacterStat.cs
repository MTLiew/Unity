using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterStat
{
    public string name;
    public float baseValue;

    private bool isDirty = true;
    private float _value;

    private readonly List<StatModifier> statModifiers;

    public CharacterStat(float aBaseValue)
    {
        baseValue = aBaseValue;
        statModifiers = new List<StatModifier>();
    }

    public float Value { 
        get {  
            if (isDirty) {
                _value = CalculateFinalValue();
                isDirty = false;
            }
            
            return _value;
        } 
    }

    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        isDirty = true;
        return statModifiers.Remove(mod);
    }

    private float CalculateFinalValue()
    {
        float finalValue = baseValue;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            
            else if (mod.Type == StatModType.Percent)
            {
                finalValue *= 1 + mod.Value;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Priority < b.Priority)
            return -1;
        else if (a.Priority > b.Priority)
            return 1;
        return 0;
    }
}
