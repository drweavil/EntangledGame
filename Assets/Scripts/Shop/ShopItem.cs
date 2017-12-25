using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem {
    public int id = 0;
	public bool isBought = false;
    public bool isSelected = false;
    public bool nonconsumable = true;
	public int goldPrice = 0;
	public float donatePrice = 3;
    public string googlePlayID;
}
