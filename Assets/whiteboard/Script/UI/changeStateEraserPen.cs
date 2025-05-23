using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeStateEraserPen : MonoBehaviour
{
    [SerializeField] private WhiteboardMarker marker;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text buttonText;

    private bool isEraser = false;

    public void ToggleTool()
    {
        isEraser = !isEraser;
        marker.SetEraserMode(isEraser);

        if (isEraser)
        {
            buttonText.text = "Pen";
            titleText.text = "Eraser Tip Size";
        }
        else
        {
            buttonText.text = "Eraser";
            titleText.text = "Pen Tip Size";
        }
    }

    

}