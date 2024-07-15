using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedPanelPrototype : TimedObject
{
    [SerializeField] private Vector2 startingPosition;
    [SerializeField] private double appearanceOffset = 0.4;
    [SerializeField] private double disappearanceOffset = 0.7;
    
    
    // [SerializeField] private GameObject startingPositionObject;
    // [SerializeField] private GameObject targetPositionObject;

    // [SerializeField] private double timeDistance = disappearanceOffset;
    [SerializeField] private Vector2 distance = new Vector2(0, -700);

    // имитация музыки?
    public override void Start()
    {
        startingPosition = gameObject.transform.position;
        anticipationTime = AudioSettings.dspTime;
        appearanceTime = AudioSettings.dspTime + appearanceOffset;
        disappearanceTime = AudioSettings.dspTime + disappearanceOffset;
        gameObject.transform.position = startingPosition;
        // timeDistance = disappearanceTime - anticipationTime;
        // Debug.Log(AudioSettings.dspTime);
    }

    protected override void Move()
    {
        
        
        float point = (float)((AudioSettings.dspTime - anticipationTime) / disappearanceOffset);
        gameObject.transform.position = startingPosition + point * distance;
    }

    protected override void Appear()
    {
    }

    protected override void Disappear()
    {
        Destroy(gameObject);
        // Destroy(gameObject);
    }
}