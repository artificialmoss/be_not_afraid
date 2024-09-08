using UnityEngine;

public abstract class TimedObjectEvaluator : SingletonBase<TimedObjectEvaluator>
{
    public abstract HitResult EvaluateTap(SingleTapDescriptor tapDescriptor);
}