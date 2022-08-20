using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pmenuscr : MonoBehaviour
{
    public GameObject localPlayer;
    public GameObject startMenu;
    public GameObject pauseUI;
    public GameObject fpsT;
    public GameObject crosshair;
    public GameObject Music;

    public static bool inStartMenu;
    public static bool isPaused;
    public static bool showFPS;
    public static bool showCrosshair;
    public static bool toStartMenu;

    InputAction pausepressed;
    // Start is called before the first frame update
    void Start()
    {
        showFPS = true;
        showCrosshair = true;
        pausepressed = new InputAction(binding: "<Keyboard>/escape");
        pausepressed.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausepressed.triggered)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (!inStartMenu)
        {
            pauseUI.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;

            if (!showNavUI.isShowing)
                Cursor.lockState = CursorLockMode.Locked;

            if (!toStartMenu)
                MovieManager.MovieManagerobj.ResumeVideo(true);
        }
    }

    public void Pause()
    {
        if (!inStartMenu)
        {
            pauseUI.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            MovieManager.MovieManagerobj.PauseVideo(true);
        }
    }

    public void Quit()
    {
        localPlayer.transform.position = new Vector3(1.93f, 4.227f, 0f); // reset player position
        localPlayer.transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));

        showNavUI.showNavUIObj.HideBuyUI(0); // hide all UI elements
        showNavUI.showNavUIObj.HideCartUI();
        showNavUI.showNavUIObj.HideMovieUI();
        showNavUI.showNavUIObj.HideCheckoutUI();
        showNavUI.showNavUIObj.HideCanvas(showNavUI.showNavUIObj.InfoUI);
        showNavUI.showNavUIObj.HideConfirmCheckoutUI();
        showNavUI.showNavUIObj.HideCanvas(showNavUI.showNavUIObj.MessageWindow);

        foreach (Car c in BuyManager.Cars)
            c.ItemCount = 0;

        MovieManager.MovieManagerobj.StopAllVideos();

        toStartMenu = true;

        Resume();

        Cursor.lockState = CursorLockMode.Confined;
        localPlayer.SetActive(false);
        startMenu.SetActive(true);

        toStartMenu = false;
        inStartMenu = true;
    }

    public void ToggleVSync()
    {
        if (QualitySettings.vSyncCount == 1)
            QualitySettings.vSyncCount = 0;
        else
            QualitySettings.vSyncCount = 1;
    }

    public void ToggleFPSCounter()
    {
        if (showFPS)
            fpsT.SetActive(false);
        else
            fpsT.SetActive(true);
        showFPS = !showFPS;
    }

    public void ToggleCrosshair()
    {
        if (showCrosshair)
            crosshair.SetActive(false);
        else
            crosshair.SetActive(true);
        showCrosshair = !showCrosshair;
    }

    public void ToggleMusic()
    {
        if (AutoPause.AutoPauseObj.musicOn)
        {
            Music.SetActive(false);
            AutoPause.AutoPauseObj.musicOn = false;
        }
        else
        {
            Music.SetActive(true);
            AutoPause.AutoPauseObj.musicOn = true;
        }
       
    }
}
