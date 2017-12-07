using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
	public float cursorSize = 50;

	Rect crosshairRect;
	Texture crosshairTexture;
	private bool showCrosshair = false;

	void OnGUI()
	{
		if (showCrosshair) {
			float crosshairSize = Screen.width * 0.1f * cursorSize / 100;
			crosshairTexture = Resources.Load ("Textures/mousepointer") as Texture;
			crosshairRect = new Rect (Screen.width / 2 - crosshairSize / 2,
				Screen.height / 2 - crosshairSize / 2,
				crosshairSize, crosshairSize);
			GUI.DrawTexture (crosshairRect, crosshairTexture);
		}
	}

	public void displayCrosshair() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        showCrosshair = true;
	}

	public void hideCrosshair() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        showCrosshair = false;
	}
}

