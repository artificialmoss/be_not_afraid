using UnityEngine;

public abstract class TimedObjectEvaluator : SingletonBase<TimedObjectEvaluator>
{
    [SerializeField] protected const int MaxPoints = 128;
    [SerializeField] protected double offset = 0;

    public abstract HitResult EvaluateTap(SingleTapDescriptor tapDescriptor);
}