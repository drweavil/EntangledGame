using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPage : MonoBehaviour {
	public List<LevelButton> buttons = new List<LevelButton>();
	public GameObject levelsPageObj;
	public static LevelsPage levelsPage;
	static int pageItemsCount = 8;
	public int currentPage = 0;
	public int maximumPage = 0;

	void Awake(){
		levelsPage = this;
	}

	public void OpenPage(bool withSound = false){
		if (withSound) {
			AudioController.MenuButtonSound();
		}
		levelsPageObj.SetActive (true);
		maximumPage = GetPagesCount ();
		currentPage = 1;
		LevelController.levelController.menuInterface.SetActive (false);
		DrawPage (1);
	}

	public void DrawPage(int pageNumber){
		foreach (LevelButton button in buttons) {
			button.buttonObj.SetActive (false);
		}
		List<LevelInfo> info = GetLevelInfoListByPage (pageNumber);
		for (int i = 0; i < info.Count; i++) {
			buttons [i].SetButton (info [i]);
		}	
	}

	public void OpenMenuInterface(){
		AudioController.CancelSound ();
		levelsPageObj.SetActive (false);
		LevelController.levelController.menuInterface.SetActive (true);
	}

	public static List<LevelInfo> GetLevelInfoListByPage(int page){
		//List<BackpackItem> items = new List<BackpackItem> ();
		int size = LevelController.levelController.gameSessionInfo.levels.Count;
		int index = (page * pageItemsCount) - pageItemsCount;
		int count = 0;
		int deltaPageSize = size - page * pageItemsCount;
		if (deltaPageSize >= 0) {
			count = pageItemsCount;
		}
		if (deltaPageSize < 0) {
			count = pageItemsCount + deltaPageSize;
		}


		return LevelController.levelController.gameSessionInfo.levels.GetRange (index, count);
	}

	public static int GetPagesCount(){
		int value = 0;
		int size = LevelController.levelController.gameSessionInfo.levels.Count;
		if (size <= pageItemsCount) {
			value = 1;
		}

		if (size > pageItemsCount) {
			float floatPage = size / pageItemsCount;
			float roundPage = (float)System.Math.Floor (floatPage);

			if (size % pageItemsCount == 0) {
				value = (int)floatPage;
			} else {
				value = (int)(roundPage + 1);
			}
		}
		return value;
	}

	public void LeftButton(){
		AudioController.MenuButtonSound ();
		currentPage -= 1;
		if (currentPage == 0) {
			currentPage = maximumPage;
		}
		DrawPage (currentPage);
	}

	public void RightButton(){
		AudioController.MenuButtonSound ();
		currentPage += 1;
		if (currentPage == maximumPage + 1) {
			currentPage = 1;
		}
		DrawPage (currentPage);
	}


}
