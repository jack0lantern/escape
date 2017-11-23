using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 7.0f;
    public Text winText;

    void Start()
    {
		if (winText)
        	winText.text = "";
    }

    void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		transform.Translate (movement);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Win Space"))
		{
			winText.text = "You win!";
		}
	}
}
