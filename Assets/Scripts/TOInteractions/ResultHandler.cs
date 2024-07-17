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
                resultDisplayer.text = "Отлично!";
                break;
            }
            case HitResult.Result.Good:
            {
                resultDisplayer.text = "Хорошо!";
                break;
            }
            case HitResult.Result.Okay:
            {
                resultDisplayer.text = "Отбился!";
                break;
            }
            case HitResult.Result.Early:
            {
                resultDisplayer.text = "Промах!";
                break;
            }
            case HitResult.Result.Late:
            {
                resultDisplayer.text = "Промах!";
                break;
            }
            case HitResult.Result.Miss:
            {
                resultDisplayer.text = "Промах!";
                break;
            }
            case HitResult.Result.Why:
            {
                resultDisplayer.text = "Ты куда лезешь...";
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