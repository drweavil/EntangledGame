using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TemplateSquad {
	public Vector2 startPoint;
	public Vector2 endPoint;
	public static int squadMinimumPointsCount = 4;


	public List<ArrayPoint> GetPointsInSquad(List<ArrayPoint> points){
		List<ArrayPoint> squadPoints = GetAllPoints ();

		List<ArrayPoint> finalPoints = new List<ArrayPoint> ();

		foreach (ArrayPoint point in points) {
			int index = squadPoints.FindIndex (p => p.coord.IsEqualVector(point.coord));

			if (index != -1) {
				finalPoints.Add (point);
			}
			//Debug.Log (finalPoints.Count);
		}
		return finalPoints;
	}

	public List<ArrayPoint> GetRandomSquadPoints(int pointsCount){
		List<ArrayPoint> squadPoints = GetAllPoints ();
		List<ArrayPoint> finalPoints = new List<ArrayPoint> ();
		for (int i = 0; i < pointsCount; i++) {
			finalPoints.Add(LevelGenerator.levelGenerator.GetPoint (ref squadPoints));
		}
		return finalPoints;
	}

	public List<ArrayPoint> GetAllPoints(){
		List<ArrayPoint> squadPoints = new List<ArrayPoint> ();
		for (float i = startPoint.x; i <= endPoint.x; i++) {
			for (float j = startPoint.y; j <= endPoint.y; j++) {
				ArrayPoint point = new ArrayPoint ();
				point.coord = new SerializableVector2 ();
				point.coord.x = i;
				point.coord.y = j;
				squadPoints.Add (point);
			}
		}
		return squadPoints;
	}
}
