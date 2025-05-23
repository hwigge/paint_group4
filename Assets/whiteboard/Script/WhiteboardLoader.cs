using System.IO;
using UnityEngine;

public class WhiteboardLoader : MonoBehaviour
{
    void Start()
    {
        string fileName = PlayerPrefs.GetString("SavedWhiteboard", "");
        if (!string.IsNullOrEmpty(fileName))
        {
            // FIX: load from the same Screenshots folder we saved to
            string path = Path.Combine(Application.dataPath, "../Screenshots", fileName);

            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);
                texture.Apply();

                Renderer renderer = GetComponent<Renderer>();

                Material mat = new Material(Shader.Find("Unlit/Texture")); // so it doesn’t get dark
                mat.mainTexture = texture;
                renderer.material = mat;

                Debug.Log("Loaded whiteboard texture: " + path);
            }
            else
            {
                Debug.LogWarning("Saved whiteboard file not found at: " + path);
            }
        }
        else
        {
            Debug.Log("No whiteboard image filename found in PlayerPrefs.");
        }
    }
}
