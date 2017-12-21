using UnityEngine;
using System.Collections;
using System;

public class ShowPanels : MonoBehaviour
{

	public GameObject optionsPanel;
	//Store a reference to the Game Object OptionsPanel
	public GameObject optionsTint;
	//Store a reference to the Game Object OptionsTint
	public GameObject menuPanel;
	//Store a reference to the Game Object MenuPanel
	public GameObject pausePanel;
	//Store a reference to the Game Object PausePanel
	public Crosshair crosshair;
    //Store a reference to the crosshair to switch on and off
    public Person player;
    //Store a reference to the player object to access inventory
    public GameObject inventoryPanel;
    //Store a reference to the Game Object InventoryPanel

    private bool invShowing = false;
    private bool crosshairWasDisplayed;

	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel ()
	{
		optionsPanel.SetActive (true);
		optionsTint.SetActive (true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel ()
	{
		optionsPanel.SetActive (false);
		optionsTint.SetActive (false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu ()
	{
		menuPanel.SetActive (true);
		crosshair.hideCrosshair ();
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu ()
	{
		crosshair.showCrosshair();
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel ()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive (true);
        crosshairWasDisplayed = crosshair.crosshairDisplayed();
        crosshair.hideCrosshair ();
	}

    internal void ShowPlayerInv()
    {
        Debug.Log("Show inventory");
        inventoryPanel.SetActive(true);
        crosshair.hideCrosshair();
    }

    internal void HidePlayerInv()
    {
        Debug.Log("Hide inventory");
        inventoryPanel.SetActive(false);
        crosshair.showCrosshair();
    }

    internal bool TogglePlayerInv()
    {
        invShowing = !invShowing;
        if (invShowing)
        {
            ShowPlayerInv();
        }
        else
        {
            HidePlayerInv();
        }
        return invShowing;
    }

    //Call this function to deactivate and hide the Pause panel during game play
    //TODO: the cursor lockedstate stays locked provided the user never unfocuses the game.
    //  maybe have a listener for getting focus? if we can't do that, we may have to 
    //  check every frame if we should lock the cursor
    public void HidePausePanel ()
	{
		if (crosshairWasDisplayed)
            crosshair.showCrosshair();
		pausePanel.SetActive (false);
		optionsTint.SetActive (false);
	}
}
