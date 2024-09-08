using System;
using System.Collections.Generic;
using UnityEngine;

public class Synchronizer : SingletonBase<Synchronizer>
{
    [SerializeField] private SingleTapDescriptor currentTapDescriptor;
    
    [SerializeField] private AudioSource humanScream;
    [SerializeField] private AudioSource monsterScream;

    public void Start()
    {
        currentTapDescriptor.Invalidate();
    }

    public void OnTimedObjectActivation(double activationTime)
    {
        if (currentTapDescriptor.IsValidTapTime())
        {
            monsterScream.Play();
            SendToEvaluationAndDestroy();
        }
        currentTapDescriptor.Appearance = activationTime;
    }

    public void OnTimedObjectDeactivation(double deactivationTime)
    {
        if (currentTapDescriptor.IsValidAppearance())
        {
            currentTapDescriptor.Disappearance = deactivationTime;
            SendToEvaluationAndDestroy();
        }
    }

    public void OnInteractionStart(double clickTime)
    {
        currentTapDescriptor.TapTime = clickTime;
        if (currentTapDescriptor.IsValidTimedObject())
        {
            monsterScream.Play();
            SendToEvaluationAndDestroy();
        }
        else
        {
            humanScream.Play();
        }
    }

    public void OnInteractionEnd(double dropTime)
    {
        currentTapDescriptor.UntapTime = dropTime;
        SendToEvaluationAndDestroy();
    }

    private void SendToEvaluationAndDestroy()
    {
        // Debug.Log(currentTapDescriptor);
        var result = TapEvaluator.Instance.EvaluateTap(currentTapDescriptor);
        ResultHandler.Instance.DisplayResult(result);
        LevelState.Instance.HandleAttack(result.ResultState);
        currentTapDescriptor.Invalidate();
    }
}
