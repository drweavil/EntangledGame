using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartProcessController : MonoBehaviour {
	public static StartProcessController startProcessController;
	public delegate void Action();

	void Awake(){
		startProcessController = this;
	}
	public static void ActionAfterFewFrames(int frames, Action action){
		startProcessController.ActionAfterFewFramesStart(frames, action);
	}

	void ActionAfterFewFramesStart(int frames, Action action){
		StartCoroutine(ActionAfterFewFramesCoroutine (frames, action));
	}

	IEnumerator ActionAfterFewFramesCoroutine(int frames, Action action){
		for(int i = 0; i < frames; i++){
			yield return null;
		}
		action ();		
	}
}
