using UnityEngine;
using System.Collections;

public class Collectible : Interactable
{
	public Sprite invSprite;

	void Awake()
	{
		if (!invSprite) {
			invSprite = Resources.Load<Sprite> ("Sprites/Items/notexture");
		}
	}

    // Bear in mind the parent has a method for Object who
    public override void Interact(Person who)
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
