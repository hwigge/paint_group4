using System.IO;
using UnityEngine;

public class WhiteBoard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);

    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }

    // Add this method to enable saving
    public void SaveWhiteboard(string fileName = "WhiteboardCapture")
    {
        byte[] bytes = texture.EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, fileName + ".png");
        File.WriteAllBytes(path, bytes);
        Debug.Log("Whiteboard saved at: " + path);
    }
}
