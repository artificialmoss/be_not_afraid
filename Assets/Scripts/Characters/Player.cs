using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class Player : Character
{
    [SerializeField] private int goodAttackDamage = 10;
    [SerializeField] private int perfectAttackDamage = 20;
    [SerializeField] private int baseAttackDamage = 5;
    
    protected override void InitializeAttacks()
    {
        damagePerAttack.Add(Attacks.BaseAttack, baseAttackDamage);
        damagePerAttack.Add(Attacks.PerfectAttack, perfectAttackDamage);
        damagePerAttack.Add(Attacks.GoodAttack, goodAttackDamage);
    }

    public int GetHealth()
    {
        return healthController.GetHealth();
    }

    protected override void VisualizeDamage()
    {
        healthController.AdjustVisualsVertically();
    }
}