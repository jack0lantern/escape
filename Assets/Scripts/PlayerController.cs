﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : Person
{

    public float speed = 7.0f;
    public Text winText;
    public float reach = 10f;
    public Camera mainCam;

    void Start()
    {
        if (winText)
        	winText.text = "";
    }

    void PerformInteraction()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, reach))
        {
            Interactable obj = hit.transform.GetComponent<Interactable>();
            if (obj)
            {
                obj.Interact(this);
            }
            else
            {
            }
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
		if (other.gameObject.CompareTag("Finish"))
		{
			winText.text = "You win!";
		}
	}
}
