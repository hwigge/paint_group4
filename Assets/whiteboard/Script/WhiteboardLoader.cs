using System.IO;
using UnityEngine;

public class WhiteboardLoader : MonoBehaviour
{
    void Start()
    {
        string fileName = PlayerPrefs.GetString("SavedWhiteboard", null);

        if (!string.IsNullOrEmpty(fileName))
        {
            string path = Path.Combine(Application.persistentDataPath, fileName);

            if (File.Exists(path))
            {
                byte[] pngData = File.ReadAllBytes(path);
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(pngData);

                // Apply texture directly to this object's material (your canvas cube)
                Renderer r = GetComponent<Renderer>();
                r.material = new Material(Shader.Find("Unlit/Texture"));
                r.material.mainTexture = tex;

                // Make it grabbable
                /* if (!GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>())
                {
                    gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
                } */

                Rigidbody rb = gameObject.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = false;
            }
        }
    }
}
