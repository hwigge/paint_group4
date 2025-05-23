using UnityEngine;

public class VRSaveButton : MonoBehaviour
{
    public void OnSave()
    {
        WhiteBoard board = FindObjectOfType<WhiteBoard>();
        if (board != null)
        {
            string fileName = "Whiteboard_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

            // Cleaner: Let the WhiteBoard script handle the path logic
            board.SaveWhiteboardToProjectScreenshots(fileName);

            PlayerPrefs.SetString("SavedWhiteboard", fileName);
            PlayerPrefs.Save();

            Debug.Log("Image saved to Screenshots folder: " + fileName);
        }
    }
}
