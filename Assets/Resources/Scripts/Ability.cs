using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ability", order = 1)]
public class Ability : ScriptableObject
{
    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;

    public bool attackOrSpell;
    public Entity caster;

    public Weapon wepRequired;
    public SkillTree skillRequired; //as in you need this skill tree
    public int proficiencyRequired;

    public double baseDamage;
    public double physicalScaling;
    public double magicalScaling;

    public List<Vector3> attackRange; //the list of tiles it hits

    public double abilityDamage()
    {
        double total;

        total = baseDamage + (1 * physicalScaling) + (1 * magicalScaling);

        return total;
    }
}