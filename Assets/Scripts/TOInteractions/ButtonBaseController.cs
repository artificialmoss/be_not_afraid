using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBaseController : EventTrigger
{
    public override void OnPointerDown(PointerEventData data)
    {
        // Debug.Log("TAP " + AudioSettings.dspTime);
        Synchronizer.Instance.OnInteractionStart(AudioSettings.dspTime);
    }

    public override void OnPointerUp(PointerEventData data)
    {
        // Debug.Log("UNTAP " + AudioSettings.dspTime);
        Synchronizer.Instance.OnInteractionEnd(AudioSettings.dspTime);
    }
}