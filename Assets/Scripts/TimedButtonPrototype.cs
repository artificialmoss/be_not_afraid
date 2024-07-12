using System;
using UnityEngine;

public class TimedButtonPrototype : TimedObject
{
    private CanvasRenderer _renderer;
    
    // имитация музыки?
    public override void Start()
    {
        appearanceTime = AudioSettings.dspTime + 15;
        disappearanceTime = AudioSettings.dspTime + 20;
        _renderer = gameObject.GetComponent<CanvasRenderer>();
        _renderer.cull = true;
        Debug.Log(AudioSettings.dspTime);
    }

    protected override void Appear()
    {
        _renderer.cull = false;
        Debug.Log("APPEAR?");
    }

    protected override void Disappear()
    {
        _renderer.cull = false;
        Debug.Log("DISAPPEAR");
    }
}