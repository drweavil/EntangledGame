using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level  {
	public int levelID;
	public int width;
	public int height;
	public int maximumPointID = 0;
	public List<ArrayPoint> points = new List<ArrayPoint>();
	public List<ArrayLine> lines = new List<ArrayLine>();



	public bool LineInterceptOtherLine(ArrayLine line){
		bool value = false;

		foreach (ArrayLine oldLine in lines) {
			if (GameMath.LinesIntercept (oldLine.GetLine(), line.GetLine())) {
				value = true;
			}
		}

		return value;
	}

	public void AddPoint(ArrayPoint point){
		maximumPointID += 1;
		point.ID = maximumPointID;
		points.Add (point);
	}
}
