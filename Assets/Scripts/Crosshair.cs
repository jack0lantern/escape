using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
	public float cursorSize = 50;

	Rect crosshairRect;
	Texture crosshairTexture;

	void Start()
	{
		float crosshairSize = Screen.width * 0.1f * cursorSize / 100;
		crosshairTexture = Resources.Load ("Textures/mousepointer") as Texture;
		crosshairRect = new Rect (Screen.width / 2 - crosshairSize / 2,
			Screen.height / 2 - crosshairSize / 2,
			crosshairSize, crosshairSize);
	}

	void OnGUI()
	{
		GUI.DrawTexture (crosshairRect, crosshairTexture);
	}
}

