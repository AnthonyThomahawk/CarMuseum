using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuscript : MonoBehaviour
{
    public GameObject MainGame;
    public GameObject StartMenu;
    public GameObject HelpMenu;

    public void Start()
    {
        pmenuscr.inStartMenu = true;
    }

    public void GoToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MainGame.SetActive(true);
        StartMenu.SetActive(false);
        pmenuscr.inStartMenu = false;
    }

    public void OpenHelp()
    {
        HelpMenu.SetActive(true);
    }

    public void CloseHelp()
    {
        HelpMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
