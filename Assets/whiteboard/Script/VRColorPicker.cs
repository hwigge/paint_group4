using Meta.XR.ImmersiveDebugger.UserInterface;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class VRColorPicker : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Image previewImage;
    public WhiteboardMarker targetPen;
    public TMP_Text RED, GREEN, BLUE;
    public int colorIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        Color initialColor = Color.black;
        redSlider.value = initialColor.r;
        greenSlider.value = initialColor.g;
        blueSlider.value = initialColor.b;
        UpdateValue(redSlider.value, greenSlider.value, blueSlider.value);
        //to change color as soon as slider is moved.
        redSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        greenSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        blueSlider.onValueChanged.AddListener(delegate { UpdateColor(); });
        // Set initial color
        UpdateColor();
    }
    void UpdateValue(float r, float g, float b) {
        RED.text = r.ToString("F2"); // Format to 2 decimal places
        BLUE.text = b.ToString("F2"); // Format to 2 decimal places
        GREEN.text = g.ToString("F2"); // Format to 2 decimal places

    }


    public void UpdateColor()
    {
        Color selectedColor = new Color(
            redSlider.value,
            greenSlider.value,
            blueSlider.value
            );

        previewImage.color = selectedColor;
       /*  if (targetPen != null && selectedColor != null)
        {
            int size = targetPen._colors.Length;
            for (int i = 0; i < size; i++)
            {
                targetPen._colors[i] = selectedColor;
            } */

            targetPen.SetColor(selectedColor);
            //targetPen._colors = selectedColor;


        }
    }
    

