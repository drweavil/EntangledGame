using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class LanguageController : MonoBehaviour {
	public static LanguageController languageController;
	public Text continueButton;
	public Text newGameButton;
	public Text levelsButton;
	public Text shopButton;
	public Text settingsButton;
	public Text goldShopButton;
	public Text skipLevelButton;
	public Text setThemeButton;
	public Text nextLevelButton;

	public Text languageLabel;
	public Text audioLabel;
	public Text levelComplete;

	public static JSONNode jsonFile;


	void Awake(){
		languageController = this;
		StartProcessController.ActionAfterFewFrames(15, () =>{
			if(GameController.gameController.currentSettings.language == ""){
				if(Application.systemLanguage == SystemLanguage.Russian || 
					Application.systemLanguage == SystemLanguage.Ukrainian || 
					Application.systemLanguage == SystemLanguage.Belarusian
				){
					SetRussian();
				} else{
					SetEnglish();
				}
			}else{
				TextAsset jsonAsset = (TextAsset)Resources.Load("Text/" + GameController.gameController.currentSettings.language);
				string jsonString = jsonAsset.text;
				jsonFile = JSON.Parse(jsonString);
				languageController.SetButtons();
			}
		});
	}



	public static void SetRussian(){
		GameController.gameController.currentSettings.language = "ru";
		TextAsset jsonAsset = (TextAsset)Resources.Load ("Text/ru");
		string jsonString = jsonAsset.text;
		jsonFile = JSON.Parse(jsonString);
		languageController.SetButtons();
		SaveLoad.SaveGameSettings (GameController.gameController.currentSettings);
	}

	public static void SetEnglish(){
		GameController.gameController.currentSettings.language = "en";
		TextAsset jsonAsset = (TextAsset)Resources.Load ("Text/en");
		string jsonString = jsonAsset.text;
		jsonFile = JSON.Parse(jsonString);
		languageController.SetButtons();
		SaveLoad.SaveGameSettings (GameController.gameController.currentSettings);
	}

	public void SetButtons(){
		continueButton.text = jsonFile ["menuButtons"] ["continue"];
		newGameButton.text = jsonFile ["menuButtons"] ["newGame"];
		levelsButton.text = jsonFile ["menuButtons"] ["levels"];
		shopButton.text = jsonFile ["menuButtons"] ["shop"];
		settingsButton.text = jsonFile ["menuButtons"] ["settings"];
		goldShopButton.text = jsonFile ["menuButtons"] ["goldShop"];
		skipLevelButton.text = jsonFile ["menuButtons"] ["skipLevel"];
		setThemeButton.text = jsonFile ["menuButtons"] ["setTheme"];
		nextLevelButton.text = jsonFile ["menuButtons"] ["nextLevel"];

		languageLabel.text = jsonFile ["labels"] ["language"];
		audioLabel.text = jsonFile ["labels"] ["audio"];
		levelComplete.text = jsonFile ["labels"] ["levelComplete"];


	}
}
