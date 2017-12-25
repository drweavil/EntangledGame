using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static GameController gameController;
	public GameSettings currentSettings;

	void Awake(){
		gameController = this;
		if (!SaveLoad.GameSettingsExist ()) {
			GameSettings settings = new GameSettings ();
			SaveLoad.SaveGameSettings (settings);
			currentSettings = settings;
		} else {
			currentSettings = SaveLoad.LoadGameSettings ();
		}
	}
}
