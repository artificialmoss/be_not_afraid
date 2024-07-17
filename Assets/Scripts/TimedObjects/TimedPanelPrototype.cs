using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedPanelPrototype : TimedObject
{
    [SerializeField] private Vector2 startingPosition;

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

        timings = TimedObjectsState.Timings.GenerateFromNow();

        timeDistance = TimedObjectsState.Instance.attackSpeedModifier * TimedObjectsState.Timings.TimeDistance();
    }

    protected override void Move()
    {
        float point = (float)((AudioSettings.dspTime - timings.anticipationTime) / timeDistance);
        gameObject.transform.position = startingPosition + (point * distance);
    }

    protected override void Appear()
    {
    }

    protected override void Disappear()
    {
    }

    protected override void DestroyTO()
    {
        Destroy(gameObject);
    }
}