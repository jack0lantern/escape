using UnityEngine;
using System.Collections;

// Obsolete... or is it? (thinking of putting a showPanels in playercontroller instead)
public class Inventory : MonoBehaviour
{
    public Person player;
    private bool inventoryToggled;

    void DisplayInventory()
    {
        Debug.Log("Display inventory");
        // player.inventory
    }

    void HideInventory()
    {
        Debug.Log("Hide inventory");
        // 
    }

    void ToggleInventory()
    {
        inventoryToggled = !inventoryToggled;
        if (inventoryToggled)
        {
            DisplayInventory();
        }
        else
        {
            HideInventory();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }
}