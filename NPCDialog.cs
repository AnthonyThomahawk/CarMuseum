using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public static NPCDialog NPCDialogObj;

    public GameObject StartDialog;
    public GameObject ShowcaseDialog;
    public GameObject CinemaDialog;
    public GameObject ShopDialog;
    public GameObject DialogCanvas;

    public void Init()
    {
        showNavUI.showNavUIObj.ShowCanvas(DialogCanvas);
        StartDialog.SetActive(true);
        ShopDialog.SetActive(false);
        CinemaDialog.SetActive(false);
        ShowcaseDialog.SetActive(false);
    }


    public void onClickShowcaseDlg()
    {
        StartDialog.SetActive(false);
        ShowcaseDialog.SetActive(true);
    }

    public void onClickCinemaDlg()
    {
        StartDialog.SetActive(false);
        CinemaDialog.SetActive(true);
    }

    public void onClickShopDlg()
    {
        StartDialog.SetActive(false);
        ShopDialog.SetActive(true);
    }

    public void onClickExit()
    {
        showNavUI.showNavUIObj.HideCanvas(DialogCanvas);
        StartDialog.SetActive(true);
        ShopDialog.SetActive(false);
        CinemaDialog.SetActive(false);
        ShowcaseDialog.SetActive(false);
    }

    public void onClickPurchase()
    {
        onClickExit();
        showNavUI.showNavUIObj.ShowCartUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        NPCDialogObj = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
