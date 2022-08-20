using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PaymentInfo
{
    public string Name;
    public string LastName;
    public string Phone;
    public string Email;
    public string CN;
    public string EM;
    public string ED;
    public string EY;
    public string CVC;
    public int CardType;

    public PaymentInfo(string N, string LN, string P, string E, string _CN, string _EM, string _ED, string _EY, string C, int CT)
    {
        Name = N;
        LastName = LN;
        Phone = P;
        Email = E;
        CN = _CN;
        EM = _EM;
        ED = _ED;
        EY = _EY;
        CVC = C;
        CardType = CT;
    }
}

public class CheckoutManager : MonoBehaviour
{
    public Toggle MasterCard;
    public Toggle Visa;
    public Toggle Maestro;
    public InputField Name;
    public InputField LastName;
    public InputField PhoneNumber;
    public InputField Email;
    public InputField CardNumber;
    public InputField ExpireMonth;
    public InputField ExpireDay;
    public InputField ExpireYear;
    public InputField CVC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool FieldCheck()
    {
        if (Name.text.Equals("") || LastName.text.Equals("") || PhoneNumber.text.Equals("") || CardNumber.text.Equals("") || ExpireMonth.text.Equals("") || ExpireDay.text.Equals("") || ExpireYear.text.Equals("") || CVC.text.Equals(""))
            return false;

        if (MasterCard.isOn == false && Visa.isOn == false && Maestro.isOn == false )
            return false;

        return true;
    }

    bool DateCheck()
    {
        int M = Convert.ToInt32(ExpireMonth.text);
        int D = Convert.ToInt32(ExpireDay.text);
        int Y = Convert.ToInt32(ExpireYear.text);

        if (M > 12 || M < 1)
            return false;
        if (D > 31 || D < 1)
            return false;

        DateTime expire = new DateTime(Y, M, D);

        if (expire < DateTime.Now)
            return false;

        return true;
    }

    public void OnClickFinishCheckout()
    {
        if (!FieldCheck())
        {
            showNavUI.showNavUIObj.HideCheckoutUI();
            showNavUI.showNavUIObj.ShowMessage("Please fill out all the necessary fields!");
        }
        else if (!DateCheck())
        {
            showNavUI.showNavUIObj.HideCheckoutUI();
            showNavUI.showNavUIObj.ShowMessage("Invalid expiration date!");
        }
        else
        {
            showNavUI.showNavUIObj.HideCheckoutUI();
            int CardType = 0;
            if (MasterCard.isOn)
                CardType = 1;
            else if (Visa.isOn)
                CardType = 2;
            else
                CardType = 3;
            PayManager.PayManagerObj.ClientInfo = new PaymentInfo(Name.text, LastName.text, PhoneNumber.text, Email.text, CardNumber.text, ExpireMonth.text, ExpireDay.text, ExpireYear.text, CVC.text, CardType);
            showNavUI.showNavUIObj.ShowConfirmCheckoutUI();
        }
    }

    public void OnClickRadioMasterCard()
    {
        MasterCard.SetIsOnWithoutNotify(true);
        Visa.SetIsOnWithoutNotify(false);
        Maestro.SetIsOnWithoutNotify(false);
    }

    public void OnClickRadioVisa()
    {
        MasterCard.SetIsOnWithoutNotify(false);
        Visa.SetIsOnWithoutNotify(true);
        Maestro.SetIsOnWithoutNotify(false);
    }

    public void OnClickRadioMaestro()
    {
        MasterCard.SetIsOnWithoutNotify(false);
        Visa.SetIsOnWithoutNotify(false);
        Maestro.SetIsOnWithoutNotify(true);
    }

    public void OnClickBackBtn()
    {
        showNavUI.showNavUIObj.HideCheckoutUI();
        showNavUI.showNavUIObj.ShowCartUI();
    }
}
