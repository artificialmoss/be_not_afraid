using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedPanelPrototype : TimedObject
{
    [SerializeField] private Vector2 startingPosition = new Vector2(0, 350);
    [SerializeField] private Vector2 targetPosition = new Vector2(0, -350);
    [SerializeField] private double appearanceOffset = 0.4;
    [SerializeField] private double disappearanceOffset = 0.7;
    // [SerializeField] private GameObject startingPositionObject;
    // [SerializeField] private GameObject targetPositionObject;

    // имитация музыки?
    public override void Start()
    {
        anticipationTime = AudioSettings.dspTime;
        appearanceTime = AudioSettings.dspTime + appearanceOffset;
        disappearanceTime = AudioSettings.dspTime + disappearanceOffset;
        Debug.Log("знаменатель " + (disappearanceTime - anticipationTime));
        // startingPosition = startingPositionObject.transform.position;
        // targetPosition = targetPositionObject.transform.position;
        Debug.Log(AudioSettings.dspTime);
    }

    protected override void Move()
    {
        
        // Debug.Log((AudioSettings.dspTime - anticipationTime));
        
        float point = (float)((AudioSettings.dspTime - anticipationTime) / (disappearanceTime - anticipationTime));
        
        // Debug.Log("точка " + point);
        gameObject.transform.position += (Vector3)(point * (targetPosition - startingPosition));
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