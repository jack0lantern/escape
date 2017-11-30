using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 7.0f;
    public Text winText;
    public float reach = 1000f;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
		if (winText)
        	winText.text = "";
    }

    void PerformInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, reach))
        {
            Debug.Log(hit.transform.name);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PerformInteraction();
        }
    }

    // Moves as fast as frame rate to smooth moving
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
