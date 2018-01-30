using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{
    public Collectible[] inventory;
    private int nextOpenInventory = 0;
	private int selectedIndex;

    public Person()
    {
        inventory = new Collectible[10];
    }

	public void SelectItem(int index)
	{
		selectedIndex = index;
	}

    public void DeselectItem()
    {
        selectedIndex = -1;
    }

    public Collectible SelectedItem()
	{
		return inventory[selectedIndex];
	}

    public int SelectedIndex()
    {
        return selectedIndex;
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

    public Collectible Drop()
    {
        if (selectedIndex < nextOpenInventory)
            nextOpenInventory = selectedIndex;
		inventory [selectedIndex] = null;
        DeselectItem();
        return null;
    }
}
