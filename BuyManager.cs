using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car
{
    public float Price;
    public string Name;
    public int ItemCount;

    public Car(float P, string N, int IC)
    {
        Price = P;
        Name = N;
        ItemCount = IC;
    }
}

public class BuyManager : MonoBehaviour
{
    public static Car[] Cars;
    public static int CurrentInd;

    public static int ItemCountLocal;

    public static BuyManager BuyManagerObj;

    public Text ItemNameStr;
    public Text ItemCostStr;
    public Text ItemCountStr;
    public Text ItemsCostStr;
    
    public void CountUp()
    {
        ItemCountLocal++;
        ItemCountStr.text = Convert.ToString(ItemCountLocal);
        ItemsCostStr.text = (ItemCountLocal * Cars[CurrentInd].Price).ToString("0.##") + "€";
    }

    public void CountDown()
    {
        if (ItemCountLocal > 0)
        {
            ItemCountLocal--;
            ItemCountStr.text = Convert.ToString(ItemCountLocal);
            ItemsCostStr.text = (ItemCountLocal * Cars[CurrentInd].Price).ToString("0.##") + "€";
        }
    }

    public void AddItemsToCart()
    {
        Cars[CurrentInd].ItemCount += ItemCountLocal;
        showNavUI.showNavUIObj.HideBuyUI(ItemCountLocal);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cars = new Car[11];

        Cars[0] = new Car(5.1f, "Ferrari F355 Spider", 0);
        Cars[1] = new Car(2.4f, "Jeep Renegade", 0);
        Cars[2] = new Car(4.3f, "Mitsubishi EVO", 0);
        Cars[3] = new Car(5.6f, "Bugatti Chiron", 0);
        Cars[4] = new Car(2.1f, "McLaren Senna", 0);
        Cars[5] = new Car(7.1f, "Audi RS7", 0);
        Cars[6] = new Car(10f, "Royce Type A", 0);
        Cars[7] = new Car(11f, "Mini Mark III", 0);
        Cars[8] = new Car(12f, "Volkswagen Beetle", 0);
        Cars[9] = new Car(2.9f, "Cadillac Eldorado", 0);
        Cars[10] = new Car(3.6f, "Royce Ghost", 0);

        BuyManagerObj = this;

        CleanUI();
    }

    public void CleanUI()
    {
        ItemCountLocal = 0;
        ItemCountStr.text = "0";
        ItemsCostStr.text = "0€";
    }
    public void UpdateUI()
    {
        ItemNameStr.text = Cars[CurrentInd].Name;
        ItemCostStr.text = (Cars[CurrentInd].Price).ToString("0.##") + "€";
    }
}
