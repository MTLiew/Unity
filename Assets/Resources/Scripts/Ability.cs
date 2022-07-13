using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;

    public Entity caster;

    public Weapon wepRequired;
    public SkillTree skillRequired;

    public double damage;

    public List<Vector3> attackRange;
}

/*List<Entity> targetsHit()
{
    
}*/