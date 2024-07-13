using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedPanelPrototype : TimedObject
{
    private CanvasRenderer _renderer;
    private Image _color;
    
    // имитация музыки?
    public override void Start()
    {
        appearanceTime = AudioSettings.dspTime;
        disappearanceTime = AudioSettings.dspTime + 0.7;
        _renderer = gameObject.GetComponent<CanvasRenderer>();
        _color = gameObject.GetComponent<Image>();
        Debug.Log(AudioSettings.dspTime);
    }

    protected override void Appear()
    {
        _color.color = Color.cyan;
        Debug.Log("APPEAR?");
    }

    protected override void Disappear()
    {
        Debug.Log("DISAPPEAR");
        Destroy(gameObject);
    }
}