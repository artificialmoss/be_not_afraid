using System;
using UnityEngine;

public class Synchronizer : SingletonBase<Synchronizer>
{
    [SerializeField] private SingleTapDescriptor currentTapDescriptor;

    public void Start()
    {
        currentTapDescriptor.Invalidate();
    }

    public void OnTimedObjectActivation(double activationTime)
    {
        if (currentTapDescriptor.IsValidTapTime() && currentTapDescriptor.IsValidUntapTime())
        {
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
            SendToEvaluationAndDestroy();
        }
    }

    public void OnInteractionEnd(double dropTime)
    {
        currentTapDescriptor.UntapTime = dropTime;
        if (currentTapDescriptor.IsValidTimedObject() || !currentTapDescriptor.IsValidAppearance())
        {
            SendToEvaluationAndDestroy();
        }
    }

    private void SendToEvaluationAndDestroy()
    {
        var result = TapEvaluator.Instance.EvaluateTap(currentTapDescriptor);
        ResultHandler.Instance.DisplayResult(result);
        currentTapDescriptor.Invalidate();
    }
}
