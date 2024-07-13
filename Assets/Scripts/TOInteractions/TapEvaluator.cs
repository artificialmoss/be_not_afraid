using System;

public class TapEvaluator : TimedObjectEvaluator
{
    public void Start()
    {
        offset = 1000;
    }

    public override HitResult EvaluateTap(SingleTapDescriptor tapDescriptor) 
    {
        // чек валидацию данных

        if (tapDescriptor.TapTime < tapDescriptor.Appearance)
        {
            return new HitResult { ResultState = HitResult.Result.Early, BaseDamage = 0 };
        }

        if (tapDescriptor.TapTime > tapDescriptor.Appearance
            && tapDescriptor.TapTime < tapDescriptor.Disappearance)
        {
            if (tapDescriptor.TapTime >= tapDescriptor.Appearance + offset)
            {
                if (tapDescriptor.Disappearance <= tapDescriptor.Disappearance - offset)
                {
                    return new HitResult { ResultState = HitResult.Result.Perfect, BaseDamage = MaxPoints }
                        ;
                }

                return new HitResult { ResultState = HitResult.Result.Good, BaseDamage = MaxPoints };
            }

            if (tapDescriptor.Disappearance <= tapDescriptor.Disappearance - offset)
            {
                return new HitResult { ResultState = HitResult.Result.Good, BaseDamage = MaxPoints }
                    ;
            }

            return new HitResult { ResultState = HitResult.Result.Okay, BaseDamage = MaxPoints };
        }

        if (tapDescriptor.UntapTime > tapDescriptor.Disappearance)
        {
            return new HitResult { ResultState = HitResult.Result.Late, BaseDamage = 0 };
        }

        return new HitResult { ResultState = HitResult.Result.Miss, BaseDamage = 0 };
    }
}