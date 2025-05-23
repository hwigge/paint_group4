using UnityEngine;
using UnityEngine.SceneManagement;

public class VRSceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Intro";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Marker"))  // Pen must be tagged "Marker"
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
