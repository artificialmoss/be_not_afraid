using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private GameObject visualIndicator;

    public void Start()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public double HealthPercentage()
    {
        return ((double)health) / maxHealth;
    }

    public bool IsOver()
    {
        return health == minHealth;
    }

    public void Increase(int increase)
    {
        if (increase < 0)
        {
            throw new RuntimeWrappedException("The increase is a lie");
        }

        health += increase;
        if (health == maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Decrease(int decrease)
    {
        if (decrease < 0)
        {
            throw new RuntimeWrappedException("The decrease is a lie");
        }

        health -= decrease;
        if (health < minHealth)
        {
            health = minHealth;
        }
    }

    public void AdjustVisualsHorizontally()
    {
        var scale = visualIndicator.transform.localScale;
        scale.x = (float) HealthPercentage();
        visualIndicator.transform.localScale = scale;
    }
    
    public void AdjustVisualsVertically()
    {
        var scale = visualIndicator.transform.localScale;
        scale.y = (float) HealthPercentage();
        visualIndicator.transform.localScale = scale;
    }
}