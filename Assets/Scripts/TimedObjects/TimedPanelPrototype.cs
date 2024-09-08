using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimedPanelPrototype : TimedObject
{
    [SerializeField] private Vector2 startingPosition;

    // старт -- 500, центр кнопки -- -635, полкнопки -- 120
    // то есть -- появление -515 (595->600/1000), дистанция 1400, можно марджин 5/1000

    // [SerializeField] private GameObject startingPositionObject;
    // [SerializeField] private GameObject targetPositionObject;

    [SerializeField] private double timeDistance;
    [SerializeField] private Vector2 distance = new Vector2(0, -1400);

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
        Debug.Log("appear at " + gameObject.transform.position);
    }

    protected override void Disappear()
    {
        Debug.Log("disappear at " + gameObject.transform.position);

    }

    protected override void DestroyTO()
    {
        Debug.Log("destroy at " + gameObject.transform.position);

        Destroy(gameObject);
    }
}