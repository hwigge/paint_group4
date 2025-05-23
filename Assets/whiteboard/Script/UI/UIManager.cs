using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isShow = false;
    [SerializeField] private GameObject uiCanvas;

    [SerializeField] private Slider slider; //slider for value change
    [SerializeField] private TMP_Text valueText; // Dispaly value in ui
    [SerializeField] private WhiteboardMarker marker; // reference to pen
    //eraser                                                    
    [SerializeField] private Slider eraserSlider; //slider for value change
    [SerializeField] private TMP_Text eraserValueText; // Dispaly value in ui
    [SerializeField] private WhiteboardMarker eraserMarker;


    void Start() {
        
        UpdatePenValue(slider.value);
        UpdateEraserValue(eraserSlider.value);

        // Adding listeners to sliders
        slider.onValueChanged.AddListener(UpdatePenValue);
        eraserSlider.onValueChanged.AddListener(UpdateEraserValue);
    }

    //Toogle UI
    public void ToogleUI () 
    {
        isShow = !isShow;
        if (isShow) 
        {
            uiCanvas.SetActive(true);
        }
        else { uiCanvas.SetActive(false); }
        

    }

    // UI Pensize change and Dispaly


    // Update the pen size and display the value
    void UpdatePenValue(float value) {
        valueText.text = value.ToString("F2"); // Format to 2 decimal places
        Debug.Log("Pen size set to: " + value);
        marker.SetPenSize(value); // Set the pen size
    }

    // Update the eraser size and display the value
    void UpdateEraserValue(float value) {
        eraserValueText.text = value.ToString("F2"); // Format to 2 decimal places
        Debug.Log("Eraser size set to: " + value);
        eraserMarker.SetPenSize(value); // Set the eraser size
    }
}
