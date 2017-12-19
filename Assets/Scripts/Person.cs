using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{
    public Collectible[] inventory;
    private int nextOpenInventory = 0;

    public Person()
    {
        inventory = new Collectible[8];
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
        return null;
    }
}
