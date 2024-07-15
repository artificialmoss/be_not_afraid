using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TimedObject : MonoBehaviour
{
    [SerializeField] protected double anticipationTime;
    [SerializeField] protected double appearanceTime;
    [SerializeField] protected double disappearanceTime;

    [SerializeField] protected bool hasAppeared = false;

    // имитация музыки?
    public virtual void Start()
    {
        appearanceTime = AudioSettings.dspTime + 100;
        disappearanceTime = AudioSettings.dspTime + 10000;
    }

    protected abstract void Appear();

    protected abstract void Disappear();

    protected abstract void Move();

    public virtual void Update()
    {
        if (AudioSettings.dspTime < appearanceTime) return;

        if (!hasAppeared && AudioSettings.dspTime < disappearanceTime)
        {
            hasAppeared = true;
            Appear();
            Synchronizer.Instance.OnTimedObjectActivation(appearanceTime);
        }
        else
        {
            if (hasAppeared && AudioSettings.dspTime >= disappearanceTime)
            {
                hasAppeared = false;
                Disappear();
                Synchronizer.Instance.OnTimedObjectDeactivation(disappearanceTime);
            }
            else
            {
                Move();
            }
        }
    }
}