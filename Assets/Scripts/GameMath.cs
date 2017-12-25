using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMath : MonoBehaviour {
	public static bool LinesIntercept(ArrayLine line1, ArrayLine line2){
		/*
		Line line1L = new Line ();
		Line line2L = new Line ();

		//lineScript.id = lineID;
		//lineID += 1;
		Point point1 = new Point ();
		Point point2 = new Point ();
		point1.coords = line1.point1.ToVector2 ();
		point2.coords = line1.point2.ToVector2 ();
		line1L.point1 = point1;
		line1L.point2 = point2;

		Point point3 = new Point ();
		Point point4 = new Point ();
		point3.coords = line2.point1.ToVector2 ();
		point4.coords = line2.point2.ToVector2 ();
		line2L.point1 = point3;
		line2L.point2 = point4;
		*/
		//Debug.Log (LinesIntercept (line1L, line2L));
		return LinesInterceptProcessing (line1.point1.x, line1.point1.y, line1.point2.x, line1.point2.y,
			line2.point1.x, line2.point1.y, line2.point2.x, line2.point2.y);
		//return LinesIntercept (line1L, line2L);
	}

	public static bool LinesIntercept(Line line1, Line line2){
		return LinesInterceptProcessing (line1.point1.coords.x, line1.point1.coords.y, line1.point2.coords.x, line1.point2.coords.y,
			line2.point1.coords.x, line2.point1.coords.y, line2.point2.coords.x, line2.point2.coords.y);
	}

	public static bool LinesInterceptProcessing(float ax1, float ay1, float ax2, float ay2, float bx1, float by1, float bx2, float by2){
		/*float ax1 = ;
		float ay1 = ;
		float ax2 = ;
		float ay2 = ;

		float bx1 = ;
		float by1 = ;
		float bx2 = ;
		float by2 = ;*/


		float v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
		float v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
		float v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
		float v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);

		bool value = (v1 * v2 < 0) && (v3 * v4 < 0);

		if ((ax1 == bx1 && ay1 == by1) ||
		   (ax1 == bx2 && ay1 == by2) ||
		   (ax2 == bx1 && ay2 == by1) ||
		   (ax2 == bx2 && ay2 == by2)) {
			value = false;
		}

		return value;
	}
}
