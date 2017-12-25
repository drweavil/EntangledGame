using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Point : MonoBehaviour {
	public Vector2 coords;
	public Vector2 arrayCoords;
	public int ID;
	public int pointType;
	public RectTransform rectTransform;
	public Image pointImage;
	public Vector2 size = new Vector2(75f, 75f);
	public Vector2 bigSize = new Vector2(100f, 100f);

	public List<LineStatus> lines = new List<LineStatus>();

	void Awake(){
		StartProcessController.ActionAfterFewFrames (1, () => {
			if(this != null){
				transform.localScale = new Vector3 (1, 1, 1);
			}
		});
	}


	public void SetNewPosition(Vector2 newCoords){
		this.transform.position = newCoords;
		coords = newCoords;
	}


	public void RedrawPointImage(){
		if (pointType == 1) {
			pointImage.sprite = SkinController.skinController.point1;
		} else if (pointType == 2) {
			pointImage.sprite = SkinController.skinController.point2;
		} else if (pointType == 3) {
			pointImage.sprite = SkinController.skinController.point3;
		}
	}

    public void Click()
    {
        int pointInProcessCheck = LevelController.levelController.pointsInChangingProcess.FindIndex(p => p.coords == this.coords);
        if (pointInProcessCheck == -1)
        {
			AudioController.PointSound ();
            if (LevelController.levelController.checkedPoint1 == null)
            {
               // pointImage.color = Color.red;
				rectTransform.sizeDelta = bigSize;
                LevelController.levelController.checkedPoint1 = this;
            }
            else if ((LevelController.levelController.checkedPoint1 != null) && (LevelController.levelController.checkedPoint2 == null))
            {
                LevelController.levelController.checkedPoint2 = this;

                /*Vector2 point1Coord = LevelController.levelController.checkedPoint1.transform.position; 
                LevelController.levelController.checkedPoint1.SetNewPosition (this.transform.position);
                this.SetNewPosition (point1Coord);*/

                LevelController.levelController.pointsInChangingProcess.Add(LevelController.levelController.checkedPoint1);
                LevelController.levelController.pointsInChangingProcess.Add(this);
                StartChangingPointsCoord(LevelController.levelController.checkedPoint1);



                if (LevelController.levelController.checkedPoint1.ID != LevelController.levelController.checkedPoint2.ID)
                {
                    LevelController.levelController.stepsCounter += 1;
                }


				LevelController.levelController.checkedPoint1.rectTransform.sizeDelta = size;;
                //LevelController.levelController.checkedPoint1.pointImage.color = Color.white;

                LevelController.levelController.checkedPoint1 = null;
                LevelController.levelController.checkedPoint2 = null;


                LevelController.levelController.RedrawLines();
                LevelController.levelController.RestatusLines();
                LevelController.levelController.RedrawStepsNumber();
            }
        }
	}

	public void Drag(){
		this.gameObject.transform.position = Input.mousePosition;
		LevelController.levelController.RedrawLines ();
		LevelController.levelController.RestatusLines ();
	}

    


	public void StartChangingPointsCoord(Point changePoint){
		StartCoroutine (StartChangingPointsCoordCoroutine(changePoint));
	}

	IEnumerator StartChangingPointsCoordCoroutine(Point changePoint){
        Vector2 tmp = changePoint.coords;
        changePoint.coords = coords;
        coords = tmp;

        Vector2 point1Coords = coords;
        Vector2 point2Coords = changePoint.coords;
        bool pointsNotChanged = true;
        float maximumDistance = (float)System.Math.Sqrt((float)System.Math.Pow(LevelController.levelController.gameArea.rect.height, 2f) +
        (float)System.Math.Pow(LevelController.levelController.gameArea.rect.width, 2f));

        float distance = Vector2.Distance(point1Coords, point2Coords);

        float maximumSpeedCoeff = 80;
        float speedCoeff = (distance * maximumSpeedCoeff)/ maximumDistance;


        float limiter = (distance * 60) / maximumDistance;




        Vector2 point1Vector = point1Coords - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        point1Vector.Normalize ();
        point1Vector = point1Vector * speedCoeff;
        Vector2 point2Vector = point2Coords - new Vector2(changePoint.transform.position.x, changePoint.transform.position.y);
        point2Vector.Normalize();
        point2Vector = point2Vector * speedCoeff;


        int restatusLineCounter = 0;



        while (pointsNotChanged)
        {
            bool point1OnCoord = false;
            bool point2OnCoord = false;
            if (Vector2.Distance(gameObject.transform.position, point1Coords) > limiter)
            {
                gameObject.transform.position += new Vector3(point1Vector.x, point1Vector.y, 0);
            }
            else
            {
                SetNewPosition(point1Coords);
                point1OnCoord = true;
            }

            if (Vector2.Distance(changePoint.transform.position, point2Coords) > limiter)
            {
                changePoint.transform.position += new Vector3(point2Vector.x, point2Vector.y, 0);
            }
            else
            {
                changePoint.SetNewPosition(point2Coords);
                point2OnCoord = true;
            }

            LevelController.levelController.RedrawLines();
            if (restatusLineCounter == 100)
            {
                LevelController.levelController.RestatusLines();
                restatusLineCounter = 0;
            }
            else {
                restatusLineCounter += 1;
            }


            if (point1OnCoord && point2OnCoord)
            {
                pointsNotChanged = false;
            }
            else
            {
                yield return null;
            }
        }


        int point1Index = LevelController.levelController.pointsInChangingProcess.FindIndex(p => p.coords == this.coords);
        int point2Index = LevelController.levelController.pointsInChangingProcess.FindIndex(p => p.coords == changePoint.coords);
        if (point1Index != -1) {
            LevelController.levelController.pointsInChangingProcess.RemoveAt(point1Index);
        }
        if (point2Index != -1)
        {
            LevelController.levelController.pointsInChangingProcess.RemoveAt(point2Index);
        }

        if (LevelController.levelController.CheckLevelComplete())
        {
			if (!LevelController.levelController.currentLevelInfo.levelComplete) {
				LevelController.levelController.gameSessionInfo.currentGold += 100;
				LevelController.levelController.currentLevelInfo.levelComplete = true;
				LevelController.levelController.gameSessionInfo.SaveLevelInfo (LevelController.levelController.currentLevelInfo, false);
			} else {
				LevelController.levelController.gameSessionInfo.SaveLevelInfo (LevelController.levelController.currentLevelInfo);
			}
            LevelController.levelController.levelCompleteDialog.SetActive(true);
			StopWatch.stopWatch.stopWatchActive = false;
        }
        LevelController.levelController.RestatusLines();

        yield break;

    }
}
