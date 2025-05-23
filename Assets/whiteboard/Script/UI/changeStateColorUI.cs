using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeStateColorUI : MonoBehaviour
{
    private bool isShow = false;
    [SerializeField] private GameObject uiCanvas;

    public void ToggleTool()
    {
        isShow = !isShow;
        if (isShow) {
            uiCanvas.SetActive(true);
        } else { uiCanvas.SetActive(false); }

    }

    

}