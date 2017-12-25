using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour {
	public int id = 0;
	public Point point1;
	public RectTransform lineRect;
	public Point point2;
	public GameObject lineImageObject;
	public Image lineImage;
	public bool isRed = false;
	public GameObject inactiveLineImageObject;
	public Image inactiveLineImage;

	void Awake(){
		StartProcessController.ActionAfterFewFrames (1, () => {
			if(this != null){
				transform.localScale = new Vector3 (1, 1, 1);
				RedrawLine();
			}
		});
	}

	public void RedrawLine(){
		Vector2 lineDirection =   point2.transform.position - point1.transform.position;
		lineDirection.Normalize ();

		float angle = Vector3.Angle(lineDirection, new Vector3(1, 0));
		if (lineDirection.y < 0) {
			angle = 360 - angle;
		}

		//Debug.Log (new Vector2 (Vector2.Distance(point1.rectTransform.position, point2.rectTransform.position), lineRect.sizeDelta.y));
		lineRect.sizeDelta = new Vector2 (Vector2.Distance(point1.rectTransform.localPosition, point2.rectTransform.localPosition), lineRect.sizeDelta.y);
		lineRect.position = point1.transform.position;
		lineRect.rotation = Quaternion.Euler (new Vector3(0, 0, angle));
		/*lineImage.rectTransform.sizeDelta = new Vector2 (Vector2.Distance(point1.rectTransform.localPosition, point2.rectTransform.localPosition), lineImage.rectTransform.sizeDelta.y);
		lineImage.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle));
		lineImage.transform.position = point1.transform.position;

		inactiveLineImage.rectTransform.sizeDelta = new Vector2 (Vector2.Distance(point1.rectTransform.localPosition, point2.rectTransform.localPosition), inactiveLineImage.rectTransform.sizeDelta.y);
		inactiveLineImage.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle));
		inactiveLineImage.transform.position = point1.transform.position;*/
	
	}

	public bool LineIntercept(Line line){
		if (!GameMath.LinesIntercept (this, line)) {
			return false;
		} else {
			return true;
		}
	}

	public void IsRed( bool isRedStatus = false){
		isRed = isRedStatus;
		if (isRedStatus) {
			lineImageObject.SetActive (false);
			inactiveLineImageObject.SetActive (true);
		} else {
			lineImageObject.SetActive (true);
			inactiveLineImageObject.SetActive (false);
		}
	}

	public void RedrawLineImage(){
		lineImage.sprite = SkinController.skinController.line;
		inactiveLineImage.sprite = SkinController.skinController.lineRed;
	}
}
