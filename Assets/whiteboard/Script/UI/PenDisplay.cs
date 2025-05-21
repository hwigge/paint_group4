using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Meta.XR.ImmersiveDebugger.UserInterface;
using UnityEngine.Timeline;


public class PenDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private WhiteboardMarker marker;
    void Start()
    {
        UpdateValue(slider.value);
        Debug.Log("Pen Slider UI value "+ slider.value);
        slider.onValueChanged.AddListener(UpdateValue);
    }

    // Update is called once per frame
    void UpdateValue(float value)
    {
        valueText.text = value.ToString("F2");
        marker.SetPenSize(value);
    }
}
