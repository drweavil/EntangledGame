using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour {
	public static ButtonActions buttonActions;
	public delegate void Action();
	public Action cancelButtonCommonAction;

	void Awake(){
		buttonActions = this;
	}


	public void CancelButtonCommon(){
		AudioController.CancelSound ();
		cancelButtonCommonAction ();
	}
}
