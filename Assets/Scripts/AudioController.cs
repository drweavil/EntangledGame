using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	public static AudioController audioController;
	public AudioSource menuButtonSound;
	public AudioSource cancelSound;
	public AudioSource pointSound;

	void Awake(){
		audioController = this;
	}

	public static void MenuButtonSound(){
		if (GameController.gameController.currentSettings.soundActive) {
			audioController.menuButtonSound.Play ();
		}
	}

	public static void CancelSound(){
		if (GameController.gameController.currentSettings.soundActive) {
			audioController.cancelSound.Play ();
		}
	}

	public static void PointSound(){
		if (GameController.gameController.currentSettings.soundActive) {
			audioController.pointSound.Play ();
		}
	}
}
