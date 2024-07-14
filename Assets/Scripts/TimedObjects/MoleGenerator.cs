using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class MoleGenerator : TimedObjectsGenerator
{
    [SerializeField] private GameObject prefab;
    public override void CreateTimedObject()
    {
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }
}