using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class MoleGenerator : TimedObjectsGenerator
{
    [SerializeField] private GameObject prefab;
    public override void CreateTimedObject()
    {
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }

    public override void CreateTimedObjectAtTime(double beat)
    {
        var newTO = Instantiate(prefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        newTO.GetComponent<TimedObject>().SetBeat(beat);
    }
}