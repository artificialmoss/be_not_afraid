using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Shadow))]
public class ButtonGlowController : MonoBehaviour
{
    private Shadow _shadow;
    private enum Status
    {
        Nothing, LightUp, Active, CoolDown
    }

    public void Start()
    {
        _shadow = gameObject.GetComponent<Shadow>();
    }
}