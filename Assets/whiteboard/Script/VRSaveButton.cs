using UnityEngine;

public class VRSaveButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marker"))
        {
            WhiteBoard board = FindObjectOfType<WhiteBoard>();
            if (board != null)
            {
                string fileName = "Whiteboard_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                board.SaveWhiteboard(fileName);

                // Save the filename so the other scene knows what to load
                PlayerPrefs.SetString("SavedWhiteboard", fileName);
                PlayerPrefs.Save();
            }

            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
