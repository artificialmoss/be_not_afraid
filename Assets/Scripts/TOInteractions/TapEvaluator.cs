using System;
using UnityEngine;

public class TapEvaluator : TimedObjectEvaluator
{
    [SerializeField] private double appearanceLength = 0.717 - 0.44;
    [SerializeField] private double perfectOffset = 0.05;
    [SerializeField] private double marginOfError = 0.15;

    public override HitResult EvaluateTap(SingleTapDescriptor tapDescriptor)
    {
        // ПЕРЕДЕЛАТЬ ЦЕЛИКОМ?


        // чек валидацию данных
        if (!tapDescriptor.IsValidTimedObject())
        {
            if (tapDescriptor.IsValidTap() && !tapDescriptor.IsValidAppearance())
            {
                return new HitResult { ResultState = HitResult.Result.Why, BaseDamage = 0 };
            }

            tapDescriptor.Disappearance = appearanceLength + tapDescriptor.Appearance;
        }

        if (!tapDescriptor.IsValidTap())
        {
            return new HitResult { ResultState = HitResult.Result.Miss, BaseDamage = 0 };
        }

        if (tapDescriptor.TapTime > tapDescriptor.Appearance + perfectOffset &&
            tapDescriptor.UntapTime + perfectOffset < tapDescriptor.Disappearance)
        {
            return new HitResult() { ResultState = HitResult.Result.Perfect, BaseDamage = 0 };
        }

        if (tapDescriptor.TapTime > tapDescriptor.Appearance && tapDescriptor.UntapTime < tapDescriptor.Disappearance)
        {
            return new HitResult { ResultState = HitResult.Result.Good, BaseDamage = 0 };
        }

        if (tapDescriptor.TapTime + marginOfError > tapDescriptor.Appearance &&
            tapDescriptor.UntapTime < tapDescriptor.Disappearance + marginOfError)
        {
            return new HitResult { ResultState = HitResult.Result.Okay, BaseDamage = 0 };
        }

        return new HitResult { ResultState = HitResult.Result.Miss, BaseDamage = 0 };
    }
}