using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : EventTrigger
{
    public void OnClick()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
