using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Vector2 mouselook;
	Vector2 smoothV;
	public float sensitivity = 2.0f;
	public float smoothing = 2.0f;
	public GameObject pause;

	private GameObject player;
	private bool frozen;

	public void Freeze() {
		frozen = true;
	}

	public void Unfreeze() {
		frozen = false;
	}

	// Use this for initialization
	void Start ()
	{
		player = transform.parent.gameObject;
	}

	// Runs every frame, like update, but runs after all processing done in update
	void LateUpdate ()
	{
		if (!frozen) {
			var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
			float moveFactor = sensitivity * smoothing;
			md = Vector2.Scale (md, new Vector2 (moveFactor, moveFactor));
			smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
			smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
			mouselook += smoothV;

			transform.localRotation = Quaternion.AngleAxis (-mouselook.y, Vector3.right);
			player.transform.localRotation = Quaternion.AngleAxis (mouselook.x, player.transform.up);
		}
	}
}