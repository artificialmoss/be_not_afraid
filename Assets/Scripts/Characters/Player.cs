using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class Player : MonoBehaviour
{
    [SerializeField] private int baseAttackDamage = 10;
    [SerializeField] private int perfectAttackDamage = 20;
    [SerializeField] private int okayAttackDamage = 5;

    private Dictionary<HitResult.Result, int> _attackDamage = new Dictionary<HitResult.Result, int>();
    
    [SerializeField] private HealthController healthController;

    private void InitializeAttacks()
    {
        _attackDamage.Add(HitResult.Result.Good, baseAttackDamage);
        _attackDamage.Add(HitResult.Result.Perfect, perfectAttackDamage);
        _attackDamage.Add(HitResult.Result.Okay, okayAttackDamage);
    }

    public int GetHealth()
    {
        return healthController.GetHealth();
    }
    
    public void Start()
    {
        healthController = gameObject.GetComponent<HealthController>();
        InitializeAttacks();
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new RuntimeWrappedException("Player is trying to take negative damage: " + damage);
        }
        healthController.Decrease(damage);
    }

    public int GiveDamage(HitResult.Result result)
    {
        if (!_attackDamage.ContainsKey(result))
        {
            throw new RuntimeWrappedException("Player is trying to give damage when the attack has failed");
        }

        return _attackDamage[result];
    }
}