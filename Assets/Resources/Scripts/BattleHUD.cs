using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHUD : MonoBehaviour
{
    public Canvas playerInterface;
    public GameObject BattleMenu;
    public GameObject AttackMenu;
    public GameObject SkillMenu;

    private void Awake()
    {
    }

    public void toggleAttackMenu()
    {
        BattleMenu.SetActive(!BattleMenu.activeSelf);
        AttackMenu.SetActive(!AttackMenu.activeSelf);
    }

    public void toggleSkillMenu()
    {
        BattleMenu.SetActive(!BattleMenu.activeSelf);
        SkillMenu.SetActive(!SkillMenu.activeSelf);
    }

    public void toggleItemMenu()
    {

    }
}
