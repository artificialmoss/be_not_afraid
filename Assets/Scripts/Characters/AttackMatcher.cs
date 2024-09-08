using System.Collections.Generic;

public class AttackMatcher : SingletonBase<AttackMatcher>
{
    private Dictionary<HitResult.Result, Attacks> _attacksMap = new Dictionary<HitResult.Result, Attacks>();

    void Start()
    {
        _attacksMap.Add(HitResult.Result.Early, Attacks.BaseMonsterAttack);
        _attacksMap.Add(HitResult.Result.Late, Attacks.BaseMonsterAttack);
        _attacksMap.Add(HitResult.Result.Miss, Attacks.BaseMonsterAttack);

        _attacksMap.Add(HitResult.Result.Why, Attacks.WhyAttack);

        _attacksMap.Add(HitResult.Result.Okay, Attacks.BaseAttack);
        _attacksMap.Add(HitResult.Result.Good, Attacks.GoodAttack);
        _attacksMap.Add(HitResult.Result.Perfect, Attacks.PerfectAttack);
    }

    public Attacks GetAttack(HitResult.Result result)
    {
        return _attacksMap[result];
    }

    public bool IsPlayerAttack(Attacks attack)
    {
        return attack == Attacks.BaseAttack
               || attack == Attacks.GoodAttack
               || attack == Attacks.PerfectAttack;
    }
}