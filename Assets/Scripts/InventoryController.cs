using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryController : MonoBehaviour
{
	public Person player;
	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	private StartOptions startScript;					//Reference to the StartButton script
	private Pause pause;								//Reference to the Pause script

	public void HighlightSelected()
	{
	}

	private void UpdateInv()
	{
		Transform inventorySlots = gameObject.transform.Find ("InventoryPanel").Find ("InventorySlots");
		for (int i = 0; i < player.inventory.Length; ++i) {
			Button butt = inventorySlots.GetChild (i).GetComponent<Button> ();
			if (player.inventory [i]) {
				butt.image.sprite = player.inventory [i].invSprite;
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

