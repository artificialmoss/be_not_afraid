using System.Collections.Generic;
using UnityEngine;

public abstract class TimedObjectsGenerator : SingletonBase<TimedObjectsGenerator>
{
    public abstract void CreateTimedObject();
    public abstract void CreateTimedObjectAtTime(double appearanceTime);
}