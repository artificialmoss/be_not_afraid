using TMPro;
using UnityEngine;

public class ResultHandler : SingletonBase<ResultHandler>
{
    [SerializeField] private TextMeshProUGUI resultDisplayer;

    public void DisplayResult(HitResult result)
    {
        switch (result.ResultState)
        {
            case HitResult.Result.Perfect:
            {
                resultDisplayer.text = "Perfect";
                break;
            }
            case HitResult.Result.Good:
            {
                resultDisplayer.text = "Good";
                break;
            }
            case HitResult.Result.Okay:
            {
                resultDisplayer.text = "Okay";
                break;
            }
            case HitResult.Result.Early:
            {
                resultDisplayer.text = "Early";
                break;
            }
            case HitResult.Result.Late:
            {
                resultDisplayer.text = "Late";
                break;
            }
            case HitResult.Result.Miss:
            {
                resultDisplayer.text = "Miss";
                break;
            }
            case HitResult.Result.Why:
            {
                resultDisplayer.text = "Miss (no attack)";
                break;
            }
            default:
            {
                resultDisplayer.text = "RESULTHANDLER.CS : 49 [ERROR]";
                //todo log error / crash because something is wrong
                break;
            }
        }
    }
}