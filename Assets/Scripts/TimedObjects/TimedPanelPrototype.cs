using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedPanelPrototype : TimedObject
{
    [SerializeField] private Vector2 startingPosition;
    [SerializeField] private double appearanceOffset = 0.44;
    [SerializeField] private double disappearanceOffset = 0.717;
    [SerializeField] private double destructionOffset = 1;

    // старт -- 100, центр кнопки -- -615, полкнопки -- 120
    // то есть -- появление -495 (595->600/1000), исчезновение 835/1000, можно марджин 5/1000

    // [SerializeField] private GameObject startingPositionObject;
    // [SerializeField] private GameObject targetPositionObject;

    [SerializeField] private double timeDistance;
    [SerializeField] private Vector2 distance = new Vector2(0, -965);

    // имитация музыки?
    public override void Start()
    {
        startingPosition = gameObject.transform.position;
        
        anticipationTime = AudioSettings.dspTime;
        appearanceTime = AudioSettings.dspTime + appearanceOffset;
        disappearanceTime = AudioSettings.dspTime + disappearanceOffset;
        destructionTime = AudioSettings.dspTime + destructionOffset;
        
        timeDistance = destructionTime - anticipationTime;
    }

    protected override void Move()
    {
        float point = (float)((AudioSettings.dspTime - anticipationTime) / timeDistance);
        gameObject.transform.position = startingPosition + (point * distance);
    }

    protected override void Appear()
    {
        // Debug.Log("APPEAR at " + gameObject.transform.position);
    }

    protected override void Disappear()
    {
        // Debug.Log("Disappear at " + gameObject.transform.position);
        // Destroy(gameObject);
        // Destroy(gameObject);
    }

    protected override void DestroyTO()
    {
        Destroy(gameObject);
    }
}