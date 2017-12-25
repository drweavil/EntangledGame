using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
	public static LevelController levelController;
	public List<Line> lines = new List<Line> ();
	public Point checkedPoint1;
	public Point checkedPoint2;
    public List<Point> pointsInChangingProcess = new List<Point>();
	public List<Point> points = new List<Point> ();

	public GameObject pointObjects;
	public GameObject lineObjects;
	public RectTransform gameArea;
	public GameObject levelCompleteDialog;
	public GameObject gameInterface;
	public GameObject menuInterface;
	public GameObject continueButton;

	public int stepsCounter = 0;
	public Text stepsNumber;
	public Text gold;
	public Text stopWatch;

	//public List<List<Point>> level = List<List<Point>>();
	public Level level;
	public LevelInfo currentLevelInfo;
	public GameSessionInfo gameSessionInfo;
	public bool gameSessionActive = false;

	public int lol = 5;
	public CanvasScaler canvasScaler;

	void Awake(){
		//Debug.Log (Screen.height);
		//canvasScaler.referenceResolution = new Vector2(Screen.currentResolution.height, Screen.currentResolution.width);
		//canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
		levelController = this;
		if (SaveLoad.GameSessionInfoExist ()) {
			gameSessionInfo = SaveLoad.LoadGameSessionInfo ();
			continueButton.SetActive (true);
		} else {
			continueButton.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			NewLevel ();

		}

		if (Input.GetKeyDown (KeyCode.X)) {
			ClearScene();
			ArrayLine line1 = new ArrayLine ();
			ArrayLine line2 = new ArrayLine ();

			SerializableVector2 line1Point1 = new SerializableVector2 ();
			line1Point1.x = 1;
			line1Point1.y = 1;
			SerializableVector2 line1Point2 = new SerializableVector2 ();
			line1Point2.x = 4;
			line1Point2.y = 1;
			line1.point1 = line1Point1;
			line1.point1ID = 1;
			line1.point2 = line1Point2;
			line1.point2ID = 2;

			/*SerializableVector2 line2Point1 = new SerializableVector2 ();
			line2Point1.x = 2;
			line2Point1.y = 2;
			SerializableVector2 line2Point2 = new SerializableVector2 ();
			line2Point2.x = 3;
			line2Point2.y = 1;
			line2.point1 = line2Point1;
			line2.point2 = line2Point2;*/

			ArrayPoint arrayPoint1 = new ArrayPoint ();
			arrayPoint1.coord = line1Point1;
			arrayPoint1.isNullPoint = false;
			arrayPoint1.ID = 1;
			ArrayPoint arrayPoint2 = new ArrayPoint ();
			arrayPoint2.coord = line1Point2;
			arrayPoint2.isNullPoint = false;
			arrayPoint2.ID = 2;


			Level newLevel = new Level ();
			newLevel.width = 10;
			newLevel.height = 20;
			newLevel.points.Add (arrayPoint1);
			newLevel.points.Add (arrayPoint2);
			newLevel.lines.Add (line1);
			//newLevel.lines.Add (line2);
			level = newLevel;

			DrawLevel ();
			//Debug.Log( LevelGenerator.IsValidLevel (newLevel));

			SkinController.skinController.SetTheme (gameSessionInfo.currentTheme);


			//line1.point1  
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			






			int levelPointsCount = 0;
			float maxPoints = 125f;
			float maximumNumber = 250f;

			float plusCoeff = 9f;
			float numberMin = 5f;
			float number = (float)lol;
			float numberCoeff = maximumNumber + numberMin - number;

			float coeff = ((plusCoeff*numberCoeff)/maximumNumber);

			//Debug.Log (coeff);
			levelPointsCount = (int)(System.Math.Round ((float)((float)maxPoints * ((float)coeff + (float)number)) / (float)maximumNumber));



			Debug.Log (lol.ToString() + " " + levelPointsCount);
			lol += 1;
			//Debug.Log((0.000001f * 300)/5);
		}
	}

	public void NewGameButton(){
		AudioController.MenuButtonSound ();
		if (SaveLoad.GameSessionInfoExist ()) {
			DialogWindowController.dialogWindowController.OpenDialog (
				LanguageController.jsonFile["dialogMessages"]["newLevelMessage"],
				(object[] buttonParams) => {
					NewGame ();
				}
			);
		} else {
			NewGame ();
		}
	}


	public void NewGame(){
		SaveLoad.DestroySaves ();
		gameSessionInfo = new GameSessionInfo ();
        gameSessionInfo.shopItems = ShopPage.shopPage.ThemesList();
		NewLevel ();	
		menuInterface.SetActive (false);
		gameInterface.SetActive (true);
		SaveLoad.SaveGameSessionInfo (gameSessionInfo);
		SkinController.skinController.SetTheme (gameSessionInfo.currentTheme);
		gameSessionActive = true;
	}

	public void SkipLevelButton(){
		int goldPrice = 100;
		AudioController.MenuButtonSound ();
		if(gameSessionInfo.currentGold >= goldPrice){
			DialogWindowController.dialogWindowController.OpenDialog (
				string.Format(LanguageController.jsonFile["dialogMessages"]["skipLevelMessage"], goldPrice.ToString()), 
				(object[] actionParams) => {
					gameSessionInfo.currentGold -= goldPrice;
					//int levelInfoIndex = gameSessionInfo.levels.FindIndex(l => l ==currentLevelInfo);
					currentLevelInfo.steps = 0;
					currentLevelInfo.time = 0;
					/*gameSessionInfo.levels[levelInfoIndex].steps = 0;
					gameSessionInfo.levels[levelInfoIndex].time = 0;*/
					NewLevel();
			});
		}else{
			DialogWindowController.dialogWindowController.OpenDialog (string.Format(LanguageController.jsonFile["dialogMessages"]["skipLevelNotEnoughtGoldMessage"], goldPrice.ToString()));
		}
	}

	public void OpenMenu(){
		AudioController.MenuButtonSound ();
		gameInterface.SetActive (false);
		menuInterface.SetActive (true);
		StopWatch.stopWatch.stopWatchActive = false;
	}

	public void ContinueGame(bool withSound = false){
		if (withSound) {
			AudioController.MenuButtonSound ();
		}
		if (gameSessionActive) {
			menuInterface.SetActive (false);
			gameInterface.SetActive (true);
			StopWatch.stopWatch.stopWatchActive = true;
		} else {
			ClearScene ();
			gameSessionInfo = SaveLoad.LoadGameSessionInfo ();
			level = SaveLoad.LoadLevel (gameSessionInfo.currentLevel);
			stepsCounter = 0;
			currentLevelInfo = gameSessionInfo.levels.Find (l => l.levelID == gameSessionInfo.currentLevel);
			menuInterface.SetActive (false);
			levelCompleteDialog.SetActive (false);
			gameInterface.SetActive (true);
			SkinController.skinController.SetTheme (gameSessionInfo.currentTheme);
			DrawLevel ();
			gameSessionActive = true;
		}
	}

	public void NewLevel(){
		ClearScene ();
		level = LevelGenerator.GetLevelByNumber(gameSessionInfo.currentLevel);
		//level = LevelGenerator.levelGenerator.GenerateLevel(10, 20, 200, 50, false);
		levelCompleteDialog.SetActive (false);
		stepsCounter = 0;
		currentLevelInfo = new LevelInfo ();
		currentLevelInfo.levelID = SaveLoad.SaveLevel (level);
		LevelInfo newLevelInfo = new LevelInfo ();
		newLevelInfo.levelID = currentLevelInfo.levelID;

		gameSessionInfo.levels.Add (newLevelInfo);
		gameSessionInfo.currentLevel = currentLevelInfo.levelID;
		SaveLoad.SaveGameSessionInfo (gameSessionInfo);
		SkinController.skinController.SetTheme (gameSessionInfo.currentTheme);
		DrawLevel ();
	}

	public void LoadLevel(int id){
		ClearScene ();
		level = SaveLoad.LoadLevel (id);
		stepsCounter = 0;
		levelCompleteDialog.SetActive (false);
		currentLevelInfo = gameSessionInfo.GetLevelInfoById(id);
		SkinController.skinController.SetTheme (gameSessionInfo.currentTheme);
		DrawLevel ();
	}

	public void NewLevelButton(){
		AudioController.MenuButtonSound ();
		SaveLevelInfo ();
		levelCompleteDialog.SetActive (false);
		if (currentLevelInfo.levelID == gameSessionInfo.currentLevel) {
			NewLevel ();
		} else {
			gameInterface.SetActive (false);
			LevelsPage.levelsPage.OpenPage ();
			//LoadLevel (currentLevelInfo.levelID + 1);
		}
	}

	public void SaveLevelInfo(){
		currentLevelInfo.steps = stepsCounter;
		SaveLoad.SaveGameSessionInfo (gameSessionInfo);
	}

	public void ClearScene(){
		
		foreach(Transform child in pointObjects.transform){
			Destroy(child.gameObject);
		}

		foreach(Transform child in lineObjects.transform){
			Destroy(child.gameObject);
		}

		points.Clear ();
		lines.Clear ();
		checkedPoint1 = null;
		checkedPoint2 = null;
		level = null;
	}

	public void DrawLevel(){
		GameObject pointPrefab = (GameObject)Resources.Load ("Prefabs/point");
		GameObject linePrefab = (GameObject)Resources.Load ("Prefabs/line");

		//List<ArrayPoint> lol = new List<ArrayPoint> ();

		foreach (ArrayPoint point in level.points) {
			if (!point.isNullPoint) {
				GameObject newPointObject = Instantiate (pointPrefab);
				newPointObject.transform.SetParent(pointObjects.transform);
				newPointObject.transform.localPosition = GetPointCoords (level.width, level.height, point.coord);
				Point newPoint = newPointObject.GetComponent<Point> ();
				newPoint.arrayCoords = point.coord.ToVector2();
				newPoint.ID = point.ID;
				newPoint.coords = newPoint.transform.position;
				newPoint.pointType = point.pointType;
				newPoint.RedrawPointImage ();
				points.Add (newPoint);
			}
		}


		foreach (ArrayLine line in level.lines) {
			GameObject newLineObj = Instantiate (linePrefab);
			newLineObj.transform.SetParent(lineObjects.transform);
			Line lineScript = newLineObj.GetComponent<Line> ();
			lineScript.RedrawLineImage ();
			lines.Add (lineScript);
			//Debug.Log (GetPointByArrayCoords (line.point1));
			lineScript.point1 = GetPointByID (line.point1ID);
			lineScript.point2 = GetPointByID (line.point2ID);
		}



		RedrawLines ();
		RestatusLines ();
		RedrawStepsNumber ();
		RestatusGold ();
		RedrawTime ();
		StopWatch.stopWatch.StartStopWatch ();
	}

	public void RestatusGold(){
		gold.text = gameSessionInfo.currentGold.ToString();
	}

	public void RedrawTime(){
		stopWatch.text = StopWatch.GetCurrentTimeInString (currentLevelInfo.time);
	}

	public bool CheckLevelComplete(){
		bool value = true;
		foreach (Line line in lines) {
			if (line.isRed) {
				value = false;
			}
		}

		return value;
	}

	public Vector2 GetPointCoords(int width, int height, SerializableVector2 arrayCoords){
		Vector2 pointCoord = new Vector2 (0, 0);

		float widthPoint = gameArea.rect.width / (float)width;
		float heightPoint = gameArea.rect.height / (float)height;

		pointCoord.x = (widthPoint * arrayCoords.x) + (widthPoint / 2);
		pointCoord.y = (heightPoint * arrayCoords.y) + (heightPoint / 2);

		pointCoord.x = pointCoord.x - (gameArea.rect.width/2);
		pointCoord.y = pointCoord.y - (gameArea.rect.height/2);

		return pointCoord;
	}

	public Point GetPointByArrayCoords(Vector2 coords){
		return points.Find (p => p.arrayCoords == coords);
	}

	public Point GetPointByID(int id){
		return points.Find (p => p.ID == id);
	}



	public void RedrawLines(){
		foreach (Line line in lines) {
			line.RedrawLine ();
		}
	}

	public void RedrawStepsNumber(){
		currentLevelInfo.steps = stepsCounter;
		stepsNumber.text = stepsCounter.ToString ();
	}

	public void RestatusLines(){
		List<Line> interceptLines = new List<Line> ();
		foreach (Line line in lines) {
			foreach (Line line2 in lines) {
				if (line != line2) {
					//Debug.Log ("hg");
					if (line.LineIntercept (line2)) {
						
						interceptLines.Add (line);
					}
				}
			}
		}

		foreach (Line line in lines) {
			line.IsRed(false);
		}

		foreach (Line line in interceptLines) {
			line.IsRed(true);
		}
	}
}
