using UnityEngine;
using System.Collections;

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
		crosshair.displayCrosshair ();
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel ()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive (true);
		crosshair.hideCrosshair ();
	}

	//Call this function to deactivate and hide the Pause panel during game play
	//TODO: the cursor lockedstate stays locked provided the user never unfocuses the game.
	//  maybe have a listener for getting focus? if we can't do that, we may have to 
	//  check every frame if we should lock the cursor
	public void HidePausePanel ()
	{
		crosshair.displayCrosshair ();
		pausePanel.SetActive (false);
		optionsTint.SetActive (false);
	}
}
