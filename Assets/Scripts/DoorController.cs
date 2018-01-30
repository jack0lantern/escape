using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Interactable {

    private Animator _animator;
	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}

    public override void Interact(Person who)
    {
        Debug.Log("Door Interact!!");
        Collectible selected = who.SelectedItem();
        if (!_animator.GetBool("Open") && selected != null && selected.name == "Main Key")
        {
            _animator.SetBool("Open", true);
            who.Drop();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
