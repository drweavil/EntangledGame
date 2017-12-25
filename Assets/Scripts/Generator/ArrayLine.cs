using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArrayLine {
	public SerializableVector2 point1;
	public SerializableVector2 point2;

	public int point1ID;
	public int point2ID;

	public Line GetLine(){
		//Debug.Log (point1);
		Line line = new Line ();
		Point linePoint1 = new Point ();
		Point linePoint2 = new Point ();
		line.point1 = linePoint1;
		line.point2 = linePoint2;

		line.point1.coords = point1.ToVector2();
		line.point2.coords = point2.ToVector2();
		return line;
	}
}
