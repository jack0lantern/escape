using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryController : MonoBehaviour
{
	public Person player;
	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	private StartOptions startScript;					//Reference to the StartButton script
	private Pause pause;								//Reference to the Pause script
    private int index = -1;

	public void ToggleSelected(GameObject slot)
	{
        Transform border = slot.transform.Find("Border");
        //GameObject go = EventSystem.current.currentSelectedGameObject;
        int oldIndex = index;
        index = slot.transform.GetSiblingIndex();
        if (player.inventory[index])
        {
            border.GetComponent<Image>().enabled = !border.GetComponent<Image>().enabled;
            Collectible tempItem = player.SelectedItem();

            // If something was selected before, disabled its border
            if (oldIndex > -1 && index != oldIndex)
            {
                slot.transform.parent.transform.GetChild(oldIndex).Find("Border").GetComponent<Image>().enabled = false;
            }
            player.DeselectItem();
            if (border.GetComponent<Image>().enabled)
            {
                player.SelectItem(index);
            }
        }
    }

    private void UpdateInv()
	{
		Transform inventorySlots = gameObject.transform.Find ("InventoryPanel").Find ("InventorySlots");
		for (int i = 0; i < player.inventory.Length; ++i) {
            // 0: border img, 1: item img
			Transform slot = inventorySlots.GetChild (i);
            Image img = slot.Find("Item").GetComponent<Image>();
			if (player.inventory [i])
            {
                img.enabled = true;
                img.sprite = player.inventory [i].invSprite;
			}
            else {
                img.enabled = false;
                slot.Find("Border").GetComponent<Image>().enabled = false;
            }
		}
	}

	void Awake()
	{
		showPanels = gameObject.GetComponent<ShowPanels> ();
		startScript = gameObject.GetComponent<StartOptions> ();
		pause = gameObject.GetComponent<Pause> ();
	}
		
	void Update()
	{
		if ((Input.GetKeyDown(KeyBindings.InventoryKey) || Input.GetKeyDown(KeyBindings.InventoryKeyAlt)) && !pause.Paused() && !startScript.inMainMenu)
		{
			showPanels.TogglePlayerInv();
		}

		UpdateInv ();
	}
}

