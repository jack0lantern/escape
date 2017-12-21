using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
	public float cursorSize = 50;

	Rect crosshairRect;
	Texture crosshairTexture;
	private bool displayCrosshair = false;

	void OnGUI()
	{
		if (displayCrosshair) {
			float crosshairSize = Screen.width * 0.1f * cursorSize / 100;
			crosshairTexture = Resources.Load ("Textures/mousepointer") as Texture;
			crosshairRect = new Rect (Screen.width / 2 - crosshairSize / 2,
				Screen.height / 2 - crosshairSize / 2,
				crosshairSize, crosshairSize);
			GUI.DrawTexture (crosshairRect, crosshairTexture);
		}
	}

	public void showCrosshair() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        displayCrosshair = true;
	}

	public void hideCrosshair() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        displayCrosshair = false;
	}
}

