using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CartManager : MonoBehaviour
{
    public GameObject DefaultItem;
    public Text DefaultItemName;
    public Text DefaultItemQty;
    public Text DefaultCost;
    public Text TotalCostTxt;
    public GameObject ListContent;
    public GameObject[] ItemList;
    public int[] ItemIDs;

    public static CartManager CartManagerObj;
    void Start()
    {
        CartManagerObj = this;
        ItemList = new GameObject[11];
        ItemIDs = new int[11];
        for (int i = 0; i<11;i++)
        {
            ItemIDs[i] = -1;
        }
    }

    public int FindIndex(int ID)
    {
        for (int i = 0; i < 11; i++)
        {
            if (ID == ItemIDs[i])
                return i;
        }

        return -1;
    }

    public float GetTotalCost()
    {
        float tc = 0;
        foreach (Car car in BuyManager.Cars)
        {
            tc += car.ItemCount * car.Price;
        }
        return tc;
    }

    public void RefreshItems()
    {
        for (int i = 0; i < 11; i++)
        {
            GameObject.Destroy(ItemList[i]);
            ItemIDs[i] = -1;
        }

        for (int i = 0; i < 11; i++)
        {
            if (BuyManager.Cars[i].ItemCount > 0)
            {
                DefaultItemName.text = BuyManager.Cars[i].Name;
                DefaultItemQty.text = BuyManager.Cars[i].ItemCount.ToString();
                DefaultCost.text = (BuyManager.Cars[i].ItemCount * BuyManager.Cars[i].Price).ToString("0.##") + "€";
                ItemList[i] = GameObject.Instantiate(DefaultItem);
                ItemList[i].transform.SetParent(ListContent.transform, false);
                ItemList[i].SetActive(true);
                ItemIDs[i] = ItemList[i].GetInstanceID();
            }
        }

        TotalCostTxt.text = GetTotalCost().ToString("0.##") + "€";
    }

    public bool hasItemsInCart()
    {
        for (int i = 0; i < 11; i++)
        {
            if (BuyManager.Cars[i].ItemCount > 0)
                return true;
        }
        return false;
    }

    public void OnClickSubBtn()
    {
        GameObject ThisBtn = EventSystem.current.currentSelectedGameObject;
        GameObject ThisItem = ThisBtn.transform.parent.gameObject;
        int Index = FindIndex(ThisItem.GetInstanceID());
        if (BuyManager.Cars[Index].ItemCount > 1)
            BuyManager.Cars[Index].ItemCount--;
        RefreshItems();
    }

    public void OnClickAddBtn()
    {
        GameObject ThisBtn = EventSystem.current.currentSelectedGameObject;
        GameObject ThisItem = ThisBtn.transform.parent.gameObject;
        int Index = FindIndex(ThisItem.GetInstanceID());
        BuyManager.Cars[Index].ItemCount++;
        RefreshItems();
    }

    public void OnClickRemoveBtn()
    {
        GameObject ThisBtn = EventSystem.current.currentSelectedGameObject;
        GameObject ThisItem = ThisBtn.transform.parent.gameObject;
        int Index = FindIndex(ThisItem.GetInstanceID());
        BuyManager.Cars[Index].ItemCount = 0;
        if (!hasItemsInCart())
        {
            showNavUI.showNavUIObj.HideCartUI();
            showNavUI.showNavUIObj.ShowMessage("Your cart is empty!");
        }
        RefreshItems();
    }

    public void OnClickOpenCheckout()
    {
        showNavUI.showNavUIObj.HideCartUI();
        showNavUI.showNavUIObj.ShowCheckoutUI();
    }
}
