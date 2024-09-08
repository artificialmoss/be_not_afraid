using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] protected HealthController healthController;

    protected Dictionary<Attacks, int> damagePerAttack = new Dictionary<Attacks, int>();

    protected abstract void InitializeAttacks();

    public void Start()
    {
        healthController = gameObject.GetComponent<HealthController>();
        InitializeAttacks();
    }

    protected abstract void VisualizeDamage();

    public void TakeDamage(int damage)
    {
        healthController.Decrease(damage);
        VisualizeDamage();
    }

    public int GiveDamage(Attacks attack)
    {
        if (!damagePerAttack.TryGetValue(attack, out var damage))
        {
            throw new RuntimeWrappedException(
                "This character (" + gameObject + ") doesn't have " + attack);
        }

        return damage;
    }
}