using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int playerSkillLevel;

    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;

    public List<SkillUpgrade> SkillList;
    public GameObject SkillHolder;

    private void Start()
    {
        SkillLevels = new int[6];
        SkillCaps = new[] {1, 3, 3, 2, 1, 1};

        SkillNames = new[] { "Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Upgrade 5", "Upgrade 6" };
        SkillDescriptions = new[]
        {
            "Upgrade 1 description",
            "Upgrade 2 description",
            "Upgrade 3 description",
            "Upgrade 4 description",
            "Upgrade 5 description",
            "Upgrade 6 description",
        };

        //foreach (var SkillUpgrade in SkillHolder.GetComponentsInChildren<SkillUpgrade>())
    }

    public Weapon aWeapon;

    public int skillName;
    public int skillLevel;
    public double skillEXP;
    

}
