using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    
    [RequireComponent(typeof(UnityEngine.UI.Image))]
    public class IntermissionTextLoader : MonoBehaviour
    {
        private UnityEngine.UI.Image panel;
        [SerializeField] private TextMeshProUGUI call;

        [Serializable]
        private enum Status
        {
            Start,
            Clear,
            Button,
            End
        }

        [SerializeField] private string nextScene;

        [SerializeField] private Status status;

        [SerializeField] private float alphaMultiplier = 0.99f;
        [SerializeField] private float alphaMultiplierIncrease = 1.01f;
        [SerializeField] private float epsMin = 0.3f;
        [SerializeField] private float epsMax = 1 - 1e-9f;

        private void Start()
        {
            panel = gameObject.GetComponent<UnityEngine.UI.Image>();
            status = Status.Start;
        }

        public void OnClick()
        {
            if (status != Status.Button) return;

            status = Status.End;
            var color = panel.color;
            if (color.a < epsMin)
            {
                color.a = epsMin;
            }

            panel.color = color;
        }

        public void Update()
        {
            switch (status)
            {
                case Status.Start:
                {
                    var color = panel.color;
                    color.a *= alphaMultiplier;
                    panel.color = color;
                    if (color.a < epsMin)
                    {
                        if (call.alpha < epsMin)
                        {
                            call.alpha = epsMin;
                        }
                        status = Status.Button;
                    }
                    break;
                }
                case Status.Clear:
                {
                    call.alpha *= alphaMultiplierIncrease;
                    if (call.alpha >= epsMax)
                    {
                        status = Status.Button;
                    }
                    break;
                }
                case Status.Button:
                {
                    break;
                }
                case Status.End:
                {
                    var color = panel.color;
                    color.a *= alphaMultiplierIncrease;
                    panel.color = color;
                    if (color.a >= epsMax)
                    {
                        SceneManager.LoadSceneAsync(nextScene);
                    }
                    break;
                }
            }
        }
    }
}