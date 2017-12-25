using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopExample : MonoBehaviour {
    public Image shopImage;
    public GameObject donatButton;
    public GameObject goldButton;
    public GameObject setThemeButton;
    public Text donatButtonText;
    public Text goldButtonText;
    public int indexInArray;
	public int shopItemsArrayCount;
    public ShopItem shopItem;


    public void SetItemShop(ShopItem item)
    {
		this.gameObject.SetActive (true);
		donatButton.SetActive (false);
		goldButton.SetActive (false);
		setThemeButton.SetActive (false);
        shopItem = item;
		if (shopItem.isBought) {
			if (!shopItem.isSelected) {
				setThemeButton.SetActive (true);
			}
		} else {
			donatButton.SetActive (true);
			goldButton.SetActive (true);
			goldButtonText.text = shopItem.goldPrice.ToString();
			donatButtonText.text = shopItem.donatePrice.ToString();
		}
		shopImage.sprite = (Sprite)Resources.Load<Sprite> ("Textures/ThemeExamples/theme_" + shopItem.id.ToString());
    }

	public void BuyDonate(){
		AudioController.MenuButtonSound ();
	}

	public void BuyGold(){
		AudioController.MenuButtonSound ();
		if (LevelController.levelController.gameSessionInfo.currentGold >= shopItem.goldPrice) {
			LevelController.levelController.gameSessionInfo.currentGold -= shopItem.goldPrice;
			int shopItemIndex = LevelController.levelController.gameSessionInfo.shopItems.FindIndex (s => s == shopItem);
			LevelController.levelController.gameSessionInfo.shopItems [shopItemIndex].isBought = true;
			shopItem = LevelController.levelController.gameSessionInfo.shopItems [shopItemIndex];
			SetItemShop (shopItem);
			LevelController.levelController.RestatusGold ();
			SaveLoad.SaveGameSessionInfo (LevelController.levelController.gameSessionInfo);
			ShopPage.shopPage.gold.text = LevelController.levelController.gameSessionInfo.currentGold.ToString ();
		} else {
			DialogWindowController.dialogWindowController.OpenDialog ("У вас не хватает золота");
		}
	}

	public void SetThemeButton(){
		AudioController.MenuButtonSound ();
		int shopItemIndex = LevelController.levelController.gameSessionInfo.shopItems.FindIndex (s => s == shopItem);
		foreach (ShopItem item in LevelController.levelController.gameSessionInfo.shopItems) {
			item.isSelected = false;
		}
		LevelController.levelController.gameSessionInfo.shopItems [shopItemIndex].isSelected = true;
		SkinController.skinController.SetTheme (shopItem.id);
		ShopPage.shopPage.OpenShopItemsPage ();
		ShopPage.shopPage.DrawButtonsByPage(ShopPage.shopPage.currentPage);
	}
}
