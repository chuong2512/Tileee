using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameHelp : MonoBehaviour 
{
	public GameObject helpObject = null;

	/// <summary>
	/// Starts the help.
	/// </summary>
	public void StartHelp()
	{
		switch (GameController.gameMode) {
		case GameMode.CLASSIC:
		case GameMode.CHALLENGE:
			ShowBasicHelp ();
			break;
		case GameMode.BLAST:
			StackManager.Instance.SpawnUIScreen ("Help-Bomb-Mode");
			PlayerPrefs.SetInt ("isHelpShown_" + GameController.gameMode.ToString (), 1);
			break;
		case GameMode.TIMED:
			GamePlay.Instance.timeSlider.PauseTimer ();
			StackManager.Instance.SpawnUIScreen ("Help-TimeMode");
			PlayerPrefs.SetInt ("isHelpShown_" + GameController.gameMode.ToString (), 1);
			break;
		case GameMode.ADVANCE:
			StackManager.Instance.SpawnUIScreen ("Help-Advance-Mode");
			PlayerPrefs.SetInt ("isHelpShown_" + GameController.gameMode.ToString (), 1);
			break;
		}

	}

	/// <summary>
	/// Shows the basic help.
	/// </summary>
	public void ShowBasicHelp() { }

	/// <summary>
	/// Stops the help.
	/// </summary>
	public void StopHelp()
	{
		helpObject = StackManager.Instance.PeekWindow ();
		StackManager.Instance.PopWindow ();

		if (helpObject != null && helpObject.name.Contains("Help-Classic")) {
			Destroy (helpObject);
			PlayerPrefs.SetInt ("isBasicHelpShown", 1);
		} 
		GamePlay.Instance.isHelpOnScreen = false;
		Destroy (this);
	}
}
