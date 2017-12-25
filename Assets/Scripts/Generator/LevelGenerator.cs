using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public static LevelGenerator levelGenerator;

	void Awake(){
		levelGenerator = this;
	}

	public Level GenerateLevel(int width, int height, int points, int mixSteps, bool withTemplates = false){
		Level level = new Level ();
		level.width = width;
		level.height = height;
		List<ArrayPoint> newPoints = new List<ArrayPoint> ();

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++){
				ArrayPoint newPoint = new ArrayPoint ();
				newPoint.coord = new SerializableVector2 ();
				newPoint.coord.x = (float)i;
				newPoint.coord.y = (float)j;
				newPoints.Add (newPoint);
			}
		}
		Template template = Template.GetStandartTemplate();

		if (withTemplates) {
			template = Template.GetTemplateByPointsCount (points);
		}

		foreach(TemplateSquad squad in template.squads){
			List<ArrayPoint> squadPoints = squad.GetRandomSquadPoints (TemplateSquad.squadMinimumPointsCount);
			foreach (ArrayPoint point in squadPoints) {
				level.AddPoint (point);

				int pointIndex = newPoints.FindIndex (p => p.coord.IsEqualVector(point.coord));
				newPoints.RemoveAt (pointIndex);
			}
		}

		for (int i = 0; i < points - template.GetTemplatePointsCount(); i++) {
			level.AddPoint(GetPoint (ref newPoints));
		}

		foreach (TemplateSquad squad in template.squads) {
			List<ArrayPoint> squadPoints = squad.GetPointsInSquad (level.points);
			bool isCircle = false;
			if(Random.Range(0, 2) == 1){
				isCircle = true;
			}
			level.lines.AddRange(SetLinesByPoints (squadPoints, isCircle));
		}

		bool levelInvalid = true;
		int validIndex = 0;
		while (levelInvalid && validIndex < 5) {
			validIndex += 1;
			MixPoints (ref level, mixSteps);
			if (IsValidLevel (level)) {
				levelInvalid = false;
			}
		}

		if (!IsValidLevel (level)) {
			level = GenerateLevel (width, height, points, mixSteps,withTemplates);

		}
		/*bool levelInvalid = true;
		while (levelInvalid) {
			MixPoints (ref level, mixSteps);
			//Debug.Log ("lols");
			if (IsValidLevel (level)) {
				levelInvalid = false;
			}
		}*/


		return level;

	}

	public void MixPoints(ref Level level, int steps){
		for (int i = 0; i < steps; i++) {
			ArrayPoint point1 = level.points [Random.Range (0, level.points.Count)];
			ArrayPoint point2 = new ArrayPoint();
			bool point2NotFount = true;
			if (level.points.Count > 1) {
				while (point2NotFount) {
					point2 = level.points [Random.Range (0, level.points.Count)];
					if (point1.ID != point2.ID) {
						point2NotFount = false;
					}
				}
			} else {
				point2 = point1;
			}

			SerializableVector2 point1Coords = point1.coord;
			point1.coord = point2.coord;
			point2.coord = point1Coords;
		}

		foreach (ArrayLine line in level.lines) {
			line.point1 = level.points.Find (p => p.ID == line.point1ID).coord;
			line.point2 = level.points.Find (p => p.ID == line.point2ID).coord;
		}
	}

	public List<ArrayLine> SetLinesByPoints(List<ArrayPoint> points, bool isCircle = false){
		List<ArrayLine> finalLines = new List<ArrayLine> ();

		List<ArrayPoint> notNullPoints = points.FindAll (p => !p.isNullPoint);

		notNullPoints = notNullPoints.OrderBy (p => p.coord.x).ToList<ArrayPoint> ();
		float minimumX =  notNullPoints[0].coord.x;
		float maximumX = notNullPoints[notNullPoints.Count - 1].coord.x;

		notNullPoints = notNullPoints.OrderBy (p => p.coord.y).ToList<ArrayPoint> ();
		float minimumY =  notNullPoints[0].coord.y;
		float maximumY = notNullPoints[notNullPoints.Count - 1].coord.y;

		Vector2 centerPoint = new Vector2 (minimumX + ((maximumX - minimumX)/2), minimumY + ((maximumY - minimumY)/2));

		List<ArrayPointInfo> pointAngles = new List<ArrayPointInfo> ();
		foreach(ArrayPoint point in notNullPoints){
			ArrayPointInfo info = new ArrayPointInfo ();
			info.coord = point.coord;
			info.pointID = point.ID;
			info.angle = GetPointAngle (point.coord.ToVector2(), centerPoint);
			pointAngles.Add (info);
		}
		pointAngles = pointAngles.OrderBy (p => p.angle).ThenBy(p => Vector2.Distance(centerPoint, p.coord.ToVector2()) * -1).ToList<ArrayPointInfo>();

		for (int i = 0; i < pointAngles.Count; i++) {
			if(i != pointAngles.Count - 1){
				ArrayLine newLine = new ArrayLine ();
				newLine.point1 = pointAngles [i].coord;
				newLine.point2 = pointAngles [i + 1].coord;

				newLine.point1ID = pointAngles [i].pointID;
				newLine.point2ID = pointAngles [i + 1].pointID;
				finalLines.Add (newLine);
			}
		}
		if (isCircle) {
			ArrayLine newLine = new ArrayLine ();
			newLine.point1 = pointAngles [0].coord;
			newLine.point2 = pointAngles [pointAngles.Count - 1 ].coord;

			newLine.point1ID = pointAngles [0].pointID;
			newLine.point2ID = pointAngles [pointAngles.Count - 1 ].pointID;
			finalLines.Add (newLine);
		}

		return finalLines;
	}

	public float GetPointAngle(Vector2 point, Vector2 centerPoint){
		Vector2 vector = centerPoint - point;
		vector.Normalize ();
		float angle = Vector3.Angle(vector, new Vector3(1, 0));
		if (vector.y < 0) {
			angle = 360 - angle;
		}

		return angle;
	}
		

	public ArrayPoint GetPoint(ref List<ArrayPoint> pointsRange){
		int pointIndex = Random.Range(0, pointsRange.Count);
		ArrayPoint newPoint = new ArrayPoint ();
		newPoint.isNullPoint = false;
		newPoint.coord = pointsRange[pointIndex].coord;
		newPoint.pointType = Random.Range (1, 4);
		pointsRange.RemoveAt (pointIndex);

		return newPoint;
	}

	public static bool IsValidLevel(Level level){
		bool value = false;
		for (int i = 0; i < level.lines.Count; i++) {
			for (int j = 0; j < level.lines.Count; j++) {
				if (level.lines[i] != level.lines[j]) {
					//Debug.Log ("kj");
					if (GameMath.LinesIntercept(level.lines[i], level.lines[j])) {
						value = true;
					}
				}
			}
		}
		return value;
	}

	public static Level GetLevelByNumber(int levelNumber){
		int levelPointsCount = 0;
		float maxPoints = 125f;
		float maximumNumber = 250f;

		if (levelNumber <= 4) {
			levelPointsCount = 5;
		} else if (levelNumber <= 300 && levelNumber > 4) {
			

			float plusCoeff = 9f;
			float numberMin = 5f;
			float number = (float)levelNumber;
			float numberCoeff = maximumNumber + numberMin - number;

			float coeff = ((plusCoeff*numberCoeff)/maximumNumber);

			//Debug.Log (coeff);
			levelPointsCount = (int)(System.Math.Round ((float)((float)maxPoints * ((float)coeff + (float)number)) / (float)maximumNumber));
		} else if (levelNumber > 300) {
			levelPointsCount = (int)maxPoints;
		}

		bool withTemplate = false;
		if (levelPointsCount >= 10 && levelPointsCount <= 25) {
			if (Random.Range (0, 2) == 1) {
				withTemplate = true;
			}
		} else if (levelPointsCount > 25) {
			withTemplate = true;
		}

		return levelGenerator.GenerateLevel (10, 20, levelPointsCount, 50, withTemplate);
	}
}
