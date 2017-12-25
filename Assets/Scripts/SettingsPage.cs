using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPage : MonoBehaviour {
	public static SettingsPage settingsPage;
	public GameObject pageObj;
	public Dropdown languageDropDown;
	public Toggle audioToggle;

	void Awake(){
		settingsPage = this;
	}

	public void OpenPage(){
		AudioController.MenuButtonSound ();
		LevelController.levelController.menuInterface.SetActive (false);
		pageObj.SetActive (true);
		SetSettings ();
	}

	public void ClosePage(){
		AudioController.CancelSound ();
		LevelController.levelController.menuInterface.SetActive (true);
		pageObj.SetActive (false);
	}

	public void ChangeLanguage(){
		if (languageDropDown.value == 0) {
			LanguageController.SetEnglish ();
		}else if (languageDropDown.value == 1) {
			LanguageController.SetRussian ();
		}
			
	}

	public void ChangeAudio(){
		GameController.gameController.currentSettings.soundActive = audioToggle.isOn;
		SaveLoad.SaveGameSettings (GameController.gameController.currentSettings);
	}

	public void SetSettings(){
		if (GameController.gameController.currentSettings.language == "en") {
			languageDropDown.value = 0;
		}else if (GameController.gameController.currentSettings.language == "ru") {
			languageDropDown.value = 1;
		}

		audioToggle.isOn = GameController.gameController.currentSettings.soundActive;

	}
}
