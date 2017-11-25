﻿using UnityEngine;
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
		crosshair.hideCrosshair ();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		crosshair.displayCrosshair ();
		optionsPanel.SetActive (false);
		optionsTint.SetActive (false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu ()
	{
		menuPanel.SetActive (true);
		crosshair.hideCrosshair ();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		crosshair.displayCrosshair ();
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel ()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive (true);
		crosshair.hideCrosshair ();
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Debug.Log (Cursor.lockState);
		crosshair.displayCrosshair ();
		pausePanel.SetActive (false);
		optionsTint.SetActive (false);
	}
}
