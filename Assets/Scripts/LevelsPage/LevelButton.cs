using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {
	public GameObject buttonObj;
	public LevelInfo levelInfo;
	public Text levelNumber;
	public Text steps;
	public Text time;

	public void SetButton(LevelInfo newLevelInfo){
		buttonObj.SetActive (true);
		levelInfo = newLevelInfo;
		levelNumber.text = levelInfo.levelID.ToString ();
		steps.text = levelInfo.steps.ToString ();
		time.text = StopWatch.GetCurrentTimeInString(levelInfo.time);
	}

	public void ButtonClick(){
		AudioController.MenuButtonSound ();
		LevelsPage.levelsPage.levelsPageObj.SetActive (false);
		LevelController.levelController.gameInterface.SetActive (true);
		LevelController.levelController.LoadLevel (levelInfo.levelID);

	}
}
