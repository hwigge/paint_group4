using OVR.OpenVR;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;

    private Renderer _renderer;
    public Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private WhiteBoard _whiteBoard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;

    private bool isEraser = false;
    private Color _penColor;

    private void Awake() {
        if (_tip == null) 
        {
            return;
        }
        _renderer = _tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }
    void Start() {
        //_renderer = _tip.GetComponent<Renderer>();
        //_colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        //_tipHeight = _tip.localScale.y;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update() {
        Draw();
    }

    public void SetPenSize(float newSize) {
        _penSize = Mathf.RoundToInt(newSize);
        if(_renderer != null) 
        {
            _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        }
        else { Debug.LogWarning("SetPen Size called, but render is still null"); }
    }

    public void SetEraserMode(bool active)
    {
        isEraser = active;
        UpdateColorArray();

        // Optionally, change the tip color to visually reflect eraser mode
        if (_renderer != null)
            _renderer.material.color = isEraser ? Color.white : _penColor;
    }

    private void UpdateColorArray()
    {
        Color currentColor = isEraser ? Color.white : _penColor;
        _colors = Enumerable.Repeat(currentColor, _penSize * _penSize).ToArray();
    }

    private void Draw() {
        if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight/5f)) {
            if (_touch.transform.CompareTag("Whiteboard")) {
                if (_whiteBoard == null) {
                    _whiteBoard = _touch.transform.GetComponent<WhiteBoard>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _whiteBoard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteBoard.textureSize.y - (_penSize / 2));

                if (y < 0 || y > _whiteBoard.textureSize.y || x < 0 || x > _whiteBoard.textureSize.x) return;

                if (_touchedLastFrame) {
                    _whiteBoard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.03f) {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteBoard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    transform.rotation = _lastTouchRot;
                    _whiteBoard.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;

            }
        }
        _whiteBoard = null;
        _touchedLastFrame = false;

    }
}