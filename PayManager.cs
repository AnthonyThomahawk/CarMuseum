using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayManager : MonoBehaviour
{
    public static PayManager PayManagerObj;
    public PaymentInfo ClientInfo;

    public Text NameStr;
    public Text PhoneStr;
    public Text EmailStr;
    public Text CardNumberStr;
    public Text ExpireDateStr;
    public Text TotalValue;

    void Start()
    {
        PayManagerObj = this;
    }
    public void InitUI()
    {
        NameStr.text = "Full Name : " + ClientInfo.Name + " " + ClientInfo.LastName;
        PhoneStr.text = "Phone number : " + ClientInfo.Phone;
        if (ClientInfo.Email.Equals(""))
            EmailStr.text = "Email : Not given";
        else
            EmailStr.text = "Email : " + ClientInfo.Email;
        CardNumberStr.text = "Card Number : " + ClientInfo.CN.Substring(0,4) + "-XXXXXX";
        ExpireDateStr.text = "Expire date : " + ClientInfo.EM + "/" + ClientInfo.ED + "/" + ClientInfo.EY;
        TotalValue.text = "Grand total : " + CartManager.CartManagerObj.GetTotalCost().ToString("0.##") + "€";
    }

    public void OnClickConfirmBtn()
    {
        showNavUI.showNavUIObj.HideConfirmCheckoutUI();

        showNavUI.showNavUIObj.ShowMessage("Checkout successful!");

        for (int i = 0; i < BuyManager.Cars.Length; i++)
        {
            BuyManager.Cars[i].ItemCount = 0;
        }
    }

    public void OnClickCancelBtn()
    {
        showNavUI.showNavUIObj.HideConfirmCheckoutUI();

        showNavUI.showNavUIObj.ShowMessage("Checkout canceled!");
    }
}
