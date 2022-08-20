using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class showNavUI : MonoBehaviour
{
    bool isHUDon;
    public static bool isShowing;
    // Start is called before the first frame update

    // Update is called once per frame

    public GameObject InteractHUD;
    public GameObject Crosshair;

    public GameObject BuyUI;
    public GameObject InfoUI;
    public GameObject CartUI;
    public GameObject CheckoutUI;
    public GameObject ConfirmCheckoutUI;
    public GameObject MovieUI;

    public GameObject MessageWindow;
    public Text MessageText;

    public static showNavUI showNavUIObj;

    void Start()
    {
        isHUDon = false;
        isShowing = false;
        showNavUIObj = this;
    }

    public void ShowCanvas(GameObject HUD)
    {
        HUD.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        isShowing = true;
        Crosshair.SetActive(false);
    }
    public void HideCanvas(GameObject HUD)
    {
        HUD.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        isShowing = false;
        if (pmenuscr.showCrosshair)
            Crosshair.SetActive(true);
    }

    public void ShowInfoUI(int Index)
    {
        InfoUIManager.InfoUIManagerObj.UpdateUI(Index);
        ShowCanvas(InfoUI);
    }

    public void ShowMessage(String message)
    {
        MessageText.text = message;
        ShowCanvas(MessageWindow);
    }

    public void ShowConfirmCheckoutUI()
    {
        PayManager.PayManagerObj.InitUI();
        ShowCanvas(ConfirmCheckoutUI);
    }
    
    public void HideConfirmCheckoutUI()
    {
        HideCanvas(ConfirmCheckoutUI);
    }

    public void ShowBuyUI(int Index)
    {
        if (!isShowing)
            BuyManager.BuyManagerObj.CleanUI();

        BuyManager.CurrentInd = Index;
        BuyManager.BuyManagerObj.UpdateUI();
        ShowCanvas(BuyUI);
    }

    public void HideBuyUI(int addedToCart)
    {
        HideCanvas(BuyUI);
        if (addedToCart > 0)
        {
            ShowMessage(addedToCart + " item(s) added to cart successfuly!");
        }
        else if (addedToCart == 0)
        {
            ShowMessage("No items added to cart!");
        }
    }

    

    public void ShowCartUI()
    {
        if (CartManager.CartManagerObj.hasItemsInCart())
        {
            CartManager.CartManagerObj.RefreshItems();
            ShowCanvas(CartUI);
        }
        else
        {
            ShowMessage("Your cart is empty!");
        }
    }

    public void HideCartUI()
    {
        HideCanvas(CartUI);
    }

    public void ShowMovieUI()
    {
        ShowCanvas(MovieUI);
    }

    public void HideMovieUI()
    {
        HideCanvas(MovieUI);
    }

    public void ShowCheckoutUI()
    {
        ShowCanvas(CheckoutUI);
    }

    public void HideCheckoutUI()
    {
        HideCanvas(CheckoutUI);
    }

    public void ShowDialogUI()
    {
        NPCDialog.NPCDialogObj.Init();
    }

    public void onClickCloseBuyUI()
    {
        isHUDon = false;
        InteractHUD.SetActive(false);
        HideBuyUI(-1);
    }

    public void onClickCloseCartUI()
    {
        isHUDon = false;
        InteractHUD.SetActive(false);
        HideCartUI();
    }

    public void onClickCloseUI()
    {
        isHUDon = false;
        InteractHUD.SetActive(false);

        HideCanvas(InfoUI);
        HideCanvas(MessageWindow);
    }

    int ScanStringArray(string[] arr, string elem)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == elem)
                return i;

        return -1;
    }

    int isCollidingWithBuy(string inCol)
    {
        string[] buyColliders = { "miniferrariCol", "miniRenegadeCol", "miniEVOcol", "miniBugattiCol", "miniSennaCol", "miniAudiR7Col", "miniRollsCol", "miniCooperCol", "miniVWCol", "miniCadillacCol", "miniGhostCol" };
        return ScanStringArray(buyColliders, inCol);
    }

    int isCollidingWithInfo(string inCol)
    {
        string[] infoColliders = { "McLarenSennaInfo",  "ChironInfo" , "BeetleInfo", "RenegadeInfo", "FerrariInfo", "CooperInfo", "AudiR7Info", "EvoInfo", "CadilacInfo", "RollsInfo", "GhostInfo"};
        return ScanStringArray(infoColliders, inCol);
    }

    bool isCollidingWithCart(string inCol)
    {
        return inCol == "cashregister";
    }

    bool isCollidingWithMovieTerminal(string inCol)
    {
        return inCol == "Computer";
    }

    bool isCollidingWithEric(string inCol)
    {
        return inCol == "rp_eric_rigged_001_yup_t";
    }

    void ShowHUD()
    {
        if (!isHUDon)
        {
            isHUDon = true;
            InteractHUD.SetActive(true);
        }
    }
    
    void HideHUD()
    {
       isHUDon = false;
       InteractHUD.SetActive(false);
    }

    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            int buyInd = isCollidingWithBuy(hit.collider.name);
            int infoInd = isCollidingWithInfo(hit.collider.name);

            if (buyInd != -1)
            {
                ShowHUD();

                if (Input.GetMouseButtonDown(0) && !isShowing) ShowBuyUI(buyInd);
            }
            else if (infoInd != -1)
            {
                ShowHUD();

                if (Input.GetMouseButtonDown(0) && !isShowing) ShowInfoUI(infoInd);
            }
            else if (isCollidingWithCart(hit.collider.name))
            {
                ShowHUD();

                if (Input.GetMouseButtonDown(0) && !isShowing) ShowCartUI();
            }
            else if (isCollidingWithMovieTerminal(hit.collider.name))
            {
                ShowHUD();

                if (Input.GetMouseButtonDown(0) && !isShowing) ShowMovieUI();
            }
            else if (isCollidingWithEric(hit.collider.name))
            {
                ShowHUD();

                if (Input.GetMouseButtonDown(0) && !isShowing) ShowDialogUI();
            }
            else
            {
                HideHUD();
            }
            if (isShowing)
            {
                HideHUD();
            }
        }
    }
}
