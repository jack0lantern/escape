using UnityEngine;
using System.Collections;

public class Collectible : Interactable
{
	public Collectible()
    {

    }

    // Bear in mind the parent has a method for Object who
    public void Interact(Person who)
    {
        Debug.Log("Collectible Interact!");
        if (!who.Obtain(this))
        {
            Debug.Log("Inventory Full!");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
