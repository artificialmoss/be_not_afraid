using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedPanelPrototype : TimedObject
{
    
    // имитация музыки?
    public override void Start()
    {
        appearanceTime = AudioSettings.dspTime;
        disappearanceTime = AudioSettings.dspTime + 0.7;
        Debug.Log(AudioSettings.dspTime);
    }

    protected override void Appear()
    {
        Debug.Log("APPEAR?");
    }

    protected override void Disappear()
    {
        Debug.Log("DISAPPEAR");
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }
}