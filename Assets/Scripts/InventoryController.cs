using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryController : MonoBehaviour
{
	public Person player;

	void Update()
	{
		Transform inventorySlots = gameObject.transform.GetChild (0);
		for (int i = 0; i < player.inventory.Length; ++i) {
			Button butt = inventorySlots.GetChild (i).GetComponent<Button> ();
			if (player.inventory [i]) {
				butt.image.sprite = player.inventory [i].invSprite;
			}
		}
	}
}

