using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MonoBehaviour {
	public Sprite point1;
	public Sprite point2;
	public Sprite point3;
	public Sprite line;
	public Sprite lineRed;
	public static SkinController skinController;
	public Image gameAreaBackground;
	public List<Sprite> atlas;

	void Awake(){
		skinController = this;
		atlas = new List<Sprite> (Resources.LoadAll<Sprite>("Textures/atlas"));
	}


	public void SetTheme(int id){
		point1 = atlas.Find (a => a.name == "point_1_" + id.ToString());
		point2 = atlas.Find (a => a.name == "point_2_" + id.ToString());
		point3 = atlas.Find (a => a.name == "point_3_" + id.ToString());
		line = atlas.Find (a => a.name == "green_line_" + id.ToString());
		lineRed = atlas.Find (a => a.name == "red_line_" + id.ToString());
		gameAreaBackground.sprite = (Sprite)Resources.Load<Sprite>("Textures/Backgrounds/background_" + id.ToString ());
		foreach (Point point in LevelController.levelController.points) {
			point.RedrawPointImage ();
		}
		foreach (Line ln in LevelController.levelController.lines) {
			ln.RedrawLineImage();
		}

		LevelController.levelController.gameSessionInfo.currentTheme = id;
		SaveLoad.SaveGameSessionInfo (LevelController.levelController.gameSessionInfo);
	}
}
