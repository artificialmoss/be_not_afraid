using UnityEngine;
    
public class SingletonBase<T> : MonoBehaviour where T: SingletonBase<T>
{
    public static T Instance { get; protected set; }
     
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        Instance = (T)this;
    }
}