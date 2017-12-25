using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPage : MonoBehaviour {
    public static ShopPage shopPage;
    static int pageItemsCount = 4;
    public int currentPage = 0;
    public int maximumPage;
    public GameObject shopPageObj;
	public GameObject shopItems;
    public ShopExample shopExample;
	public ShopItem currentItem;
	public bool exampleMode = false;
	public Text gold;
    public List<ShopItemButton> buttons = new List<ShopItemButton>();

    private void Awake()
    {
        shopPage = this;
    }


    public List<ShopItem> ThemesList() {
        List<ShopItem> list = new List<ShopItem>();

		ShopItem item0 = new ShopItem();
		item0.googlePlayID = "theme_0";
		item0.donatePrice = 15;
		item0.goldPrice = 100;
		item0.id = 0;
		item0.isBought = true;
		item0.isSelected = true;
		list.Add(item0);

        for(int i=0; i < 4; i++)
        {
            ShopItem item = new ShopItem();
            item.googlePlayID = "theme_" + (i + 1).ToString();
            item.donatePrice = 15;
            item.goldPrice = 100;
            item.id = i + 1;
            list.Add(item);
        }
        return list;
    }


    public void OpenPage()
    {
		shopItems.SetActive (true);
        shopPageObj.SetActive(true);
        LevelController.levelController.menuInterface.SetActive(false);
        LevelController.levelController.gameInterface.SetActive(false);
		gold.text = LevelController.levelController.gameSessionInfo.currentGold.ToString();
		shopExample.gameObject.SetActive (false);
        DrawButtonsByPage(1);
        maximumPage = GetPagesCount();
    }


	public void OpenFromMenu(){
		OpenPage ();
		AudioController.MenuButtonSound ();
		ButtonActions.buttonActions.cancelButtonCommonAction = () => {
			LevelController.levelController.menuInterface.SetActive (true);
			shopPageObj.SetActive (false);
		};
	}
	public void OpenFromGameInterface(){
		OpenPage ();
		AudioController.MenuButtonSound ();
		StopWatch.stopWatch.stopWatchActive = false;
		ButtonActions.buttonActions.cancelButtonCommonAction = () => {
			LevelController.levelController.gameInterface.SetActive (true);
			shopPageObj.SetActive (false);
			StopWatch.stopWatch.stopWatchActive = true;
		};
	}

	public void OpenExample(){
		shopItems.SetActive (false);
		shopExample.SetItemShop (currentItem);
	}

	public void OpenShopItemsPage(){
		shopExample.gameObject.SetActive (false);
		shopItems.SetActive (true);
		exampleMode = false;
	}




    public void DrawButtonsByPage(int page)
    {
        currentPage = page;
        foreach (ShopItemButton button in buttons)
        {
            button.buttonObj.SetActive(false);
        }

        List<ShopItem> item = GetLevelInfoListByPage(page);
        for (int i = 0; i < item.Count; i++)
        {
            buttons[i].SetButton(item[i]);
        }
    } 


    public static List<ShopItem> GetLevelInfoListByPage(int page)
    {
        //List<BackpackItem> items = new List<BackpackItem> ();
        int size = LevelController.levelController.gameSessionInfo.shopItems.Count;
        int index = (page * pageItemsCount) - pageItemsCount;
        int count = 0;
        int deltaPageSize = size - page * pageItemsCount;
        if (deltaPageSize >= 0)
        {
            count = 4;
        }
        if (deltaPageSize < 0)
        {
            count = pageItemsCount + deltaPageSize;
        }


        return LevelController.levelController.gameSessionInfo.shopItems.GetRange(index, count);
    }

    public static int GetPagesCount()
    {
        int value = 0;
        int size = LevelController.levelController.gameSessionInfo.shopItems.Count;
        if (size <= pageItemsCount)
        {
            value = 1;
        }

        if (size > pageItemsCount)
        {
            float floatPage = size / pageItemsCount;
            float roundPage = (float)System.Math.Floor(floatPage);

            if (size % pageItemsCount == 0)
            {
                value = (int)floatPage;
            }
            else
            {
                value = (int)(roundPage + 1);
            }
        }
        return value;
    }

    
    public void ButtonLeft()
    {
		AudioController.MenuButtonSound ();
		if (!exampleMode) {
			currentPage -= 1;
			if (currentPage == 0) {
				currentPage = maximumPage;
			}
			DrawButtonsByPage (currentPage);
		} else {
			shopExample.indexInArray -= 1;
			if (shopExample.indexInArray == -1) {
				shopExample.indexInArray = shopExample.shopItemsArrayCount - 1;
			}
			shopExample.SetItemShop (LevelController.levelController.gameSessionInfo.shopItems[shopExample.indexInArray]);
		}
    }

    public void ButtonRight()
    {
		AudioController.MenuButtonSound ();
		if (!exampleMode) {
			currentPage += 1;
			if (currentPage == maximumPage + 1) {
				currentPage = 1;
			}
			DrawButtonsByPage (currentPage);
		} else {
			shopExample.indexInArray += 1;
			if (shopExample.indexInArray == shopExample.shopItemsArrayCount) {
				shopExample.indexInArray = 0;
			}
			shopExample.SetItemShop (LevelController.levelController.gameSessionInfo.shopItems[shopExample.indexInArray]);
		}
    }
}
