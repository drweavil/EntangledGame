using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableVector2{
	public float x;
	public float y;

	public Vector2 ToVector2(){
		return new Vector2 (x, y);
	}

	public bool IsEqualVector(SerializableVector2 vector){
		bool value = true;
		if (vector.x != x) {
			value = false;
		}

		if (vector.y != y) {
			value = false;
		}
		return value;
	}
}
