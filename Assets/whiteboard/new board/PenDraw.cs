using UnityEngine;

public class PenDrawing : MonoBehaviour
{
    public RenderTexture renderTexture;  // The render texture to paint on
    public Camera drawingCamera;  // The camera that views the texture (Orthographic camera)
    public Texture penTexture;  // The texture representing the pen stroke
    private Material drawMaterial;  // Material used for drawing

    private void Start() {
        // Ensure the RenderTexture is cleared to a blank state
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
    }

    void Update() {
        // Only draw when the mouse or pen is being dragged
        if (Input.GetMouseButton(0)) {
            DrawOnRenderTexture();
        }
    }

    private void DrawOnRenderTexture() {
        Vector3 worldPosition = drawingCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 texturePosition = new Vector2(worldPosition.x, worldPosition.y);

        // Draw the pen texture at the current position on the render texture
        Graphics.SetRenderTarget(renderTexture);
        GL.PushMatrix();
        drawMaterial.SetTexture("_MainTex", penTexture);
        drawMaterial.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.TexCoord2(0, 0);
        GL.Vertex3(texturePosition.x, texturePosition.y, 0);
        GL.TexCoord2(1, 0);
        GL.Vertex3(texturePosition.x + 0.1f, texturePosition.y, 0);
        GL.TexCoord2(1, 1);
        GL.Vertex3(texturePosition.x + 0.1f, texturePosition.y + 0.1f, 0);
        GL.TexCoord2(0, 1);
        GL.Vertex3(texturePosition.x, texturePosition.y + 0.1f, 0);
        GL.End();
        GL.PopMatrix();

        // Reset the render target to the screen
        Graphics.SetRenderTarget(null);
    }
}
