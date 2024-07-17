using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TimedObject : MonoBehaviour
{
    [SerializeField] protected TimedObjectsState.Timings timings = TimedObjectsState.Timings.Zero();

    [Serializable]
    private enum State
    {
        Nothing,
        Anticipation,
        Appeared,
        Disappeared,
        Destroyed
    }

    [SerializeField] private State state = State.Nothing;

    // [SerializeField] protected bool hasAppeared = false;

    // public TimedObject(double appearanceTime)
    // {
    //     timings = TimedObjectsState.Timings.GenerateAtAppearanceTime(appearanceTime);
    // }

    // имитация музыки?
    public virtual void Start()
    {
    }

    public void SetBeat(double beat)
    {
        timings = TimedObjectsState.Timings.GenerateAtBeat(beat);
    }

    protected abstract void Appear();

    protected abstract void Disappear();

    protected abstract void Move();

    protected abstract void DestroyTO();

    public virtual void Update()
    {
        switch (state)
        {
            case State.Nothing:
            {
                if (AudioSettings.dspTime < timings.anticipationTime) return;
                state = State.Anticipation;
                
                goto case State.Anticipation;
            }
            case State.Anticipation:
            {
                if (AudioSettings.dspTime < timings.appearanceTime)
                {
                    Move();
                    return;
                }

                state = State.Appeared;
                Appear();
                Synchronizer.Instance.OnTimedObjectActivation(timings.appearanceTime);

                goto case State.Appeared;
            }
            case State.Appeared:
            {
                if (AudioSettings.dspTime < timings.disappearanceTime)
                {
                    Move();
                    return;
                }

                state = State.Disappeared;
                Disappear();
                Synchronizer.Instance.OnTimedObjectDeactivation(timings.disappearanceTime);

                goto case State.Disappeared;
            }
            case State.Disappeared:
            {
                Move();
                if (AudioSettings.dspTime < timings.destructionTime)
                {
                    return;
                }

                state = State.Destroyed;
                
                goto case State.Destroyed;
            }
            case State.Destroyed:
            {
                DestroyTO();
                return;
            }
        }
    }
}