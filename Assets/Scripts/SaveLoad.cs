using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {
	public static int SaveLevel(Level level, bool isPrimary = true){
		string saveFolder = "/Resources/PrimaryLevels";
		if (!isPrimary) {
			saveFolder = "/Resources/ProcessingLevels";
		}
		CreateDirectoryIfNotExist (Application.persistentDataPath + saveFolder);

		List<int> levelNames = new List<int> ();
		DirectoryInfo directory = new DirectoryInfo (Application.persistentDataPath + saveFolder);
		FileInfo[] directoryFiles = directory.GetFiles ("*.level");

		foreach (FileInfo f in directoryFiles) {
			string[] fileName = f.Name.Split ('.');
			levelNames.Add (int.Parse(fileName[0]));
		}

		int maxLevel = Mathf.Max(levelNames.ToArray());
		level.levelID = maxLevel + 1;

		FileStream file = File.Create(Application.persistentDataPath + saveFolder + "/" + (maxLevel+1).ToString() + ".level");
		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (file, level);
		file.Close ();
		return maxLevel + 1;
	}

	public static Level LoadLevel(int levelID, bool isPrimary = true){
		FileStream file;
		string levelFolder = "/Resources/PrimaryLevels/";
		if (!isPrimary) {
			levelFolder = "/Resources/ProcessingLevels/";
		}
		Level levelLoaded = new Level();
		string path = Application.persistentDataPath + levelFolder + levelID.ToString() + ".level";
		BinaryFormatter bf = new BinaryFormatter ();
		if (File.Exists (path)) {
			file = File.Open (path, FileMode.Open);
			levelLoaded = (Level)bf.Deserialize (file);
			file.Close ();
		}
		return levelLoaded;
	}

	public static void SaveGameSessionInfo(GameSessionInfo info){
		FileStream file;
		BinaryFormatter bf = new BinaryFormatter ();
		string path = Application.persistentDataPath + "/Resources/currentGameInfo.gameInfo";
		if (File.Exists (path)) {
			File.Delete (path);
		}
		file = File.Create (path);
		bf.Serialize (file, info);
		file.Close ();
		
	}

	public static bool GameSettingsExist(){
		bool value = false;
		if (File.Exists(Application.persistentDataPath + "/Resources/settings.settings")) {
			value = true;
		}
		return value;
	}


	public static void SaveGameSettings(GameSettings settings){
		FileStream file;
		BinaryFormatter bf = new BinaryFormatter ();
		string path = Application.persistentDataPath + "/Resources/settings.settings";
		if (File.Exists (path)) {
			File.Delete (path);
		}
		file = File.Create (path);
		bf.Serialize (file, settings);
		file.Close ();

	}

	public static GameSettings LoadGameSettings(){
		string path = Application.persistentDataPath + "/Resources/settings.settings";
		GameSettings loadedInfo = new GameSettings();
		FileStream file;BinaryFormatter bf = new BinaryFormatter ();
		if (File.Exists (path)) {
			file = File.Open (path, FileMode.Open);
			loadedInfo = (GameSettings)bf.Deserialize (file);
			file.Close ();
		}
		return loadedInfo;
	}

	public static bool GameSessionInfoExist(){
		bool value = false;
		if (File.Exists(Application.persistentDataPath + "/Resources/currentGameInfo.gameInfo")) {
			value = true;
		}
		return value;
	}

	public static GameSessionInfo LoadGameSessionInfo(){
		string path = Application.persistentDataPath + "/Resources/currentGameInfo.gameInfo";
		GameSessionInfo loadedInfo = new GameSessionInfo();
		FileStream file;BinaryFormatter bf = new BinaryFormatter ();
		if (File.Exists (path)) {
			file = File.Open (path, FileMode.Open);
			loadedInfo = (GameSessionInfo)bf.Deserialize (file);
			file.Close ();
		}
		return loadedInfo;
	}

	public static void DestroySaves(){
		if(File.Exists(Application.persistentDataPath + "/Resources/currentGameInfo.gameInfo")){
			File.Delete (Application.persistentDataPath + "/Resources/currentGameInfo.gameInfo");
		}
		if(Directory.Exists(Application.persistentDataPath + "/Resources/PrimaryLevels/")){
			Directory.Delete (Application.persistentDataPath + "/Resources/PrimaryLevels/", true);
		}
		if(Directory.Exists(Application.persistentDataPath + "/Resources/ProcessingLevels/")){
			Directory.Delete (Application.persistentDataPath + "/Resources/ProcessingLevels/", true);
		}
	}

	public static void CreateDirectoryIfNotExist (string path){
		if (!Directory.Exists (path)) {
			Directory.CreateDirectory (path);
		}
	}
}
