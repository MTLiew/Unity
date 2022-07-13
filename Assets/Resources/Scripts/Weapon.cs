using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { SWORD, SPEAR, STAFF }

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Type aType;

    public string aName;
    public int damage;
}
