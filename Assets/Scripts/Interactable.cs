using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public virtual void Interact (Object who)
    {
        Debug.Log("Interact!");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
