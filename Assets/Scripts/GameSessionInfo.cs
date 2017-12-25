using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSessionInfo{
	public List<LevelInfo> levels = new List<LevelInfo>();
	public int currentLevel = 0;
	public int currentTheme = 0;
	public int currentGold = 0;
	public List<ShopItem> shopItems = new List<ShopItem> ();

	public LevelInfo GetLevelInfoById(int id){
		return levels.Find (l => l.levelID == id);
	}

	public void SaveLevelInfo(LevelInfo levelInfo, bool withRewrawStats = true){

		int index = levels.FindIndex (l => l.levelID == levelInfo.levelID);
		if (index == -1) {
			levels.Add (levelInfo);
		} else {
			float oldTime = levels [index].time;
			int oldSteps = levels [index].steps;
			levels [index] = levelInfo;
			if (levels [index].levelComplete && withRewrawStats) {
				if (levelInfo.time > oldTime) {
					levels [index].time = oldTime;

				}
				if (levelInfo.steps > oldSteps) {
					levels [index].steps = oldSteps;
					Debug.Log ("lol");
				}
			}
		}

		SaveLoad.SaveGameSessionInfo (this);
	}
}
