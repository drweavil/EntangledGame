using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour {
	public static StopWatch stopWatch;

	public bool stopWatchActive = false;
	float startTime = 0;
	float time = 0;
	int frameIndex = 0;

	void Awake(){
		stopWatch = this;
	}

	void Update(){
		if (stopWatchActive) {
			time = Time.time - startTime;
			LevelController.levelController.currentLevelInfo.time = time;
			if (frameIndex == 10) {
				frameIndex = 0;
				LevelController.levelController.RedrawTime ();
			} else {
				frameIndex += 1;
			}
		}
	}

	public void StartStopWatch(){
		time = 0;
		startTime = Time.time;
		stopWatchActive = true;
	}

	public void StopStopWatch(){
		time = 0;
		stopWatchActive = false;
	}

	public void PauseStopWatch(){
		stopWatchActive = false;
	}

	public float GetCurrentTime(){
		return time;
	}

	public static string GetCurrentTimeInString(float currentTime){
		int timeH = (int)System.Math.Floor(currentTime / 3600f);
		if (timeH > 0) {
			currentTime -= timeH * 3600;
		} else {
			timeH = 0;
		}

		int timeM = (int)System.Math.Floor (currentTime/60);
		if (timeM > 0) {
			currentTime -= timeM * 60;
		}else {
			timeM = 0;
		}

		int timeS = (int)System.Math.Round (currentTime, 0);

		return timeH.ToString () + ":" + timeM.ToString () + ":" + timeS.ToString ();
	}
}
