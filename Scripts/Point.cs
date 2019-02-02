using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Point : MonoBehaviour {

    private Camera _camera;
    private bool startGame = false;
	void Start () {
        _camera = GetComponent<Camera>();
	}
    void OnGUI() {
        if (startGame) {
            int size = 30;
            float posX = _camera.pixelWidth/2 - size/4;
            float posY = _camera.pixelHeight/2 - size/2;
            GUIStyle style = new GUIStyle();
            style.fontSize = size;
            style.normal.textColor = Color.cyan;
            // GUI.color = Color.white;
            // style.
            GUI.Label(new Rect(posX, posY, size, size), "+", style);
        }
    }

    public void StartGame() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        startGame = true;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startGame = false;
    }

	// Update is called once per frame
	void Update () {

	}
}
