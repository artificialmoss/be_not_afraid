using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(HealthController))]
public class Monster : MonoBehaviour
{
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private HealthController healthController;

    public void Start()
    {
        healthController = gameObject.GetComponent<HealthController>();
    }

    public void TakeDamage(int damage)
    {
        healthController.Decrease(damage);
    }

    public int GiveDamage()
    {
        return attackDamage;
    }
    
    public int GetHealth()
    {
        return healthController.GetHealth();
    }
}