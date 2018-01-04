using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{
    public Collectible[] inventory;
    private int nextOpenInventory = 0;
	private Collectible selected;
	private int selectedIndex;

    public Person()
    {
        inventory = new Collectible[10];
    }

	public void SelectItem(int index)
	{
		selectedIndex = index;
		selected = inventory [selectedIndex];
	}

    public void DeselectItem()
    {
        selectedIndex = -1;
        selected = null;
    }

    public Collectible Selected()
	{
		return selected;
	}

    public bool Obtain(Collectible thing)
    {
        if (nextOpenInventory >= inventory.Length)
            return false;
        inventory[nextOpenInventory] = thing;
        Debug.Log("Get thing: " + inventory[nextOpenInventory].name);
        do
        {
            ++nextOpenInventory;
        } while (nextOpenInventory < inventory.Length && inventory[nextOpenInventory] != null);
        return true;
    }

    public Collectible Drop(int indexOfItem)
    {
        if (indexOfItem < nextOpenInventory)
            nextOpenInventory = indexOfItem;
		inventory [indexOfItem] = null;
        return null;
    }
}
