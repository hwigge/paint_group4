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

    // Default save method (to persistent data path, if needed elsewhere)
    public void SaveWhiteboard(string fileName = "WhiteboardCapture")
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + ".png");
        SaveWhiteboardToPath(path);
        Debug.Log("Whiteboard saved at: " + path);
    }

    // Custom save method — saves to project-root/Screenshots/
    public void SaveWhiteboardToProjectScreenshots(string fileName)
    {
        string screenshotsPath = Path.Combine(Application.dataPath, "../Screenshots");
        if (!Directory.Exists(screenshotsPath))
            Directory.CreateDirectory(screenshotsPath);

        string fullPath = Path.Combine(screenshotsPath, fileName);
        SaveWhiteboardToPath(fullPath);

        Debug.Log("Whiteboard saved to Screenshots folder: " + fullPath);
    }

    // Core method that does the actual file write
    public void SaveWhiteboardToPath(string fullPath)
    {
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(fullPath, bytes);
    }
}
