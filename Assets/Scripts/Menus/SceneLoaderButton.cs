using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderButton : MonoBehaviour
{
    [SerializeField] private string scene;
    
    public void OnClick()
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
