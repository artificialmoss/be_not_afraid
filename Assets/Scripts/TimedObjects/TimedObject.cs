using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TimedObject : MonoBehaviour
{
    [SerializeField] protected double anticipationTime;
    [SerializeField] protected double appearanceTime;
    [SerializeField] protected double disappearanceTime;
    [SerializeField] protected double destructionTime;

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

    // имитация музыки?
    public virtual void Start()
    {
        appearanceTime = AudioSettings.dspTime + 100;
        disappearanceTime = AudioSettings.dspTime + 10000;
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
                if (AudioSettings.dspTime < anticipationTime) return;
                state = State.Anticipation;
                
                goto case State.Anticipation;
            }
            case State.Anticipation:
            {
                if (AudioSettings.dspTime < appearanceTime)
                {
                    Move();
                    return;
                }

                state = State.Appeared;
                Appear();
                Synchronizer.Instance.OnTimedObjectActivation(appearanceTime);

                goto case State.Appeared;
            }
            case State.Appeared:
            {
                if (AudioSettings.dspTime < disappearanceTime)
                {
                    Move();
                    return;
                }

                state = State.Disappeared;
                Disappear();
                Synchronizer.Instance.OnTimedObjectDeactivation(disappearanceTime);

                goto case State.Disappeared;
            }
            case State.Disappeared:
            {
                Move();
                if (AudioSettings.dspTime < destructionTime)
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

        // if (AudioSettings.dspTime < anticipationTime) return;
        //
        // if (state == State.Nothing)
        // {
        //     state = State.Anticipation;
        // }
        //
        // Move();
        //
        // if (!hasAppeared && AudioSettings.dspTime >= appearanceTime)
        // {
        // }
        //
        // if (!hasAppeared && AudioSettings.dspTime < disappearanceTime)
        // {
        //     hasAppeared = true;
        //     Appear();
        //     Synchronizer.Instance.OnTimedObjectActivation(appearanceTime);
        // }
        // else
        // {
        //     if (!hasAppeared) return;
        //     if (AudioSettings.dspTime >= disappearanceTime)
        //     {
        //         hasAppeared = false;
        //         Disappear();
        //     }
        // }
    }
}