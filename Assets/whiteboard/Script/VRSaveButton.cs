using UnityEngine;

public class VRSaveButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marker"))  // Your pen object must be tagged "Marker"
        {
            WhiteBoard board = FindObjectOfType<WhiteBoard>();
            if (board != null)
            {
                string fileName = "Whiteboard_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
                board.SaveWhiteboard(fileName);
            }

            GetComponent<Renderer>().material.color = Color.green; // Optional feedback
        }
    }
}
