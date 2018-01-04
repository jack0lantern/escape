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

	public void ToggleSelected(GameObject go)
	{
        //int index = slot.transform.GetSiblingIndex();
        //GameObject go = EventSystem.current.currentSelectedGameObject;
        Debug.Log(go.GetComponentInChildren<Image>().enabled);
        go.GetComponentInChildren<Image>().enabled = true;
    }

    private void UpdateInv()
	{
		Transform inventorySlots = gameObject.transform.Find ("InventoryPanel").Find ("InventorySlots");
		for (int i = 0; i < player.inventory.Length; ++i) {
            // 0: border img, 1: item img
			Image slot = inventorySlots.GetChild (i).GetChild(1).GetComponent<Image> ();
			if (player.inventory [i]) {
                slot.enabled = true;
                slot.sprite = player.inventory [i].invSprite;
			}
            else {
                slot.enabled = false;
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
		if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.E)) && !pause.Paused() && !startScript.inMainMenu)
		{
			showPanels.TogglePlayerInv();
		}

		UpdateInv ();
	}
}

