using System;
using UnityEngine;

public class TimedObjectsState : SingletonBase<TimedObjectsState>
{
    [SerializeField] public double attackSpeedModifier = 1;

    [Serializable]
    public class Timings
    {
        [SerializeField] public double anticipationTime;
        [SerializeField] public double appearanceTime;
        [SerializeField] public double disappearanceTime;
        [SerializeField] public double destructionTime;

        [SerializeField] public static readonly double appearanceOffset = 0.44;
        [SerializeField] private static double disappearanceOffset = 0.717;
        [SerializeField] private static double destructionOffset = 1;
        [SerializeField] public static readonly double midpoint = (appearanceOffset + disappearanceOffset) / 2;

        public static double TimeDistance()
        {
            return destructionOffset;
        }

        public static Timings GenerateFromNow()
        {
            return new Timings
            {
                anticipationTime = AudioSettings.dspTime,
                appearanceTime = AudioSettings.dspTime + appearanceOffset * Instance.attackSpeedModifier,
                disappearanceTime = AudioSettings.dspTime + disappearanceOffset * Instance.attackSpeedModifier,
                destructionTime = AudioSettings.dspTime + destructionOffset * Instance.attackSpeedModifier
            };
        }

        public static Timings GenerateAtBeat(double beat)
        {
            var midpoint = (appearanceOffset + disappearanceOffset) / 2;
            var appearanceTime = beat + (appearanceOffset - midpoint) * Instance.attackSpeedModifier;
            var disappearanceTime = beat + (disappearanceOffset - midpoint) * Instance.attackSpeedModifier;
            var anticipationTime = beat - midpoint * Instance.attackSpeedModifier;
            var destructionTime = beat + (1 - midpoint) * Instance.attackSpeedModifier;
            return new Timings
            {
                anticipationTime = anticipationTime,
                appearanceTime = appearanceTime,
                disappearanceTime = disappearanceTime,
                destructionTime = destructionTime
            };
        }

        public static Timings Zero()
        {
            return new Timings
            {
                anticipationTime = 0,
                appearanceTime = appearanceOffset * Instance.attackSpeedModifier,
                disappearanceTime = disappearanceOffset * Instance.attackSpeedModifier,
                destructionTime = destructionOffset * Instance.attackSpeedModifier
            };
        }
    }
}