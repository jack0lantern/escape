using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : Person
{

    public float speed = 7.0f;
    public Text winText;
    public float reach = 10.0f;
    public Camera mainCam;
    private Rigidbody rb;
    public float jump = 5.0f;
    private float disttoground = 0;
    

    void Start()
    {
        disttoground = (GetComponent<CapsuleCollider>().height) / 2 ;
        rb = GetComponent<Rigidbody>();

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

    void jumping()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rb.velocity += new Vector3(0, jump, 0);
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
        
        //Debug.Log(isGrounded());   prints to the debug log if the player is colliding with the ground

        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		transform.Translate (movement);
        jumping();
        

        
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Finish"))
		{
			winText.text = "You win!";
		}
	}

    // returns true if player is touching ground/platform else false
    bool isGrounded()
    {
       return Physics.Raycast(transform.position, Vector3.down, disttoground);
    }
}
