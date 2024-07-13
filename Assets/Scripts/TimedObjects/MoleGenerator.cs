using UnityEngine;

public class MoleGenerator : TimedObjectsGenerator
{
    [SerializeField] private GameObject prefab;
    public override void CreateTimedObject()
    {
        Instantiate(prefab, Vector2.zero, Quaternion.identity);
    }
}