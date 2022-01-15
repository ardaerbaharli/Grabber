using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour, IPointerDownHandler
{
    public bool isOn;

    [SerializeField] private Text onText;
    [SerializeField] private Text offText;
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;

    [SerializeField] private float tweenTime = 0.25f;


    public delegate void ValueChanged(bool value);

    public event ValueChanged valueChanged;


    public void Toggle(bool value)
    {
        isOn = value;
        ToggleColor(isOn);

        if (valueChanged != null)
            valueChanged(isOn);
    }

    private void ToggleColor(bool value)
    {
        if (value)
        {
            onText.color = onColor;
            offText.color = offColor;
        }
        else
        {
            onText.color = offColor;
            offText.color = onColor;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Toggle(!isOn);
    }
}