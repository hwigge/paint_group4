using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRColorPicker : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Image previewImage;
    public WhiteboardMarker targetPen;
    public int colorIndex = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateColor()
    {
        Color selectedColor = new Color(
            redSlider.value,
            greenSlider.value,
            blueSlider.value
            );

        previewImage.color = selectedColor;
        if (targetPen != null && selectedColor != null)
        {
            int size = targetPen._colors.Length;
            for (int i = 0; i < size; i++)
            {
                targetPen._colors[i] = selectedColor;
            }



        }
    }
}
