using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string entityName;
    public int entityLevel;

    public int damage; //attack

    public int maxHP;
    public int currentHP;

    public float maxActionPoints = 2;
    public float currentActionPoints;

    
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}
