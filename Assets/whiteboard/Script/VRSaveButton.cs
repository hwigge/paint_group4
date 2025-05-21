using UnityEngine;

public class VRSaveButton : MonoBehaviour
{
    public void saveImage()
    {
        WhiteBoard board = FindObjectOfType<WhiteBoard>();
        if (board != null)
        {
            string fileName = "Whiteboard_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            board.SaveWhiteboard(fileName);

            // Save the filename so the other scene knows what to load
            PlayerPrefs.SetString("SavedWhiteboard", fileName);
            PlayerPrefs.Save();
            Debug.Log("Image Saved Triggered");
        }

        
    }
}
