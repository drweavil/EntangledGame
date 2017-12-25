using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour {
    public GameObject buttonObj;
    public GameObject standart;
    public GameObject red;
    public GameObject green;
	public Image shopItemImage;
    public int indexInArray;

    public ShopItem shopItem;


    public void SetButton(ShopItem item)
    {
        shopItem = item;
        buttonObj.SetActive(true);
        red.SetActive(false);
        standart.SetActive(false);
        green.SetActive(false);
        if (item.isBought)
        {
            if (item.isSelected)
            {
                green.SetActive(true);
            }
            else
            {
                standart.SetActive(true);
            }
        }else
        {
            red.SetActive(true);
        }
        indexInArray = GetShopItemIndex(shopItem);
		shopItemImage.sprite = (Sprite)Resources.Load<Sprite> ("Textures/ThemeExamples/theme_" + shopItem.id.ToString());
    }

	public void Click(){
		AudioController.MenuButtonSound ();
		ShopPage.shopPage.shopItems.SetActive (false);
		ShopPage.shopPage.currentItem = shopItem;
		ShopPage.shopPage.shopExample.indexInArray = indexInArray;
		ShopPage.shopPage.shopExample.shopItemsArrayCount = LevelController.levelController.gameSessionInfo.shopItems.Count;
		ShopPage.shopPage.shopExample.SetItemShop (shopItem);
		ShopPage.shopPage.exampleMode = true;
	}


    public int GetShopItemIndex(ShopItem item)
    {
        return LevelController.levelController.gameSessionInfo.shopItems.FindIndex(s => s == item);
    }
}
