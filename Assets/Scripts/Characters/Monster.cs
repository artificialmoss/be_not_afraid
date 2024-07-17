using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(HealthController))]
public class Monster : Character
{
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private int missDamage = 3;
    
    public int GetHealth()
    {
        return healthController.GetHealth();
    }

    protected override void InitializeAttacks()
    {
        damagePerAttack.Add(Attacks.BaseMonsterAttack, attackDamage);
        damagePerAttack.Add(Attacks.WhyAttack, missDamage);
    }

    protected override void VisualizeDamage()
    {
        healthController.AdjustVisualsHorizontally();
    }
}