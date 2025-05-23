using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// this change the tip size and displayes the value in the canvas.

public class sliderDIsplay : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private WhiteboardMarker marker;

    void Start()
    {
        UpdateValue(slider.value);
        Debug.Log("Pen Slider UI ");
        slider.onValueChanged.AddListener(UpdateValue);
    }

    void UpdateValue(float value)
    {
        valueText.text = value.ToString("F2"); // Format to 2 decimal places
        Debug.Log("Pen size set to: " + value);
        marker.SetPenSize(value);
    }

}
