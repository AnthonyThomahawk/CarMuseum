using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MovieManager : MonoBehaviour
{
    public GameObject Screen;
    public Text Status;
    public static MovieManager MovieManagerobj;
    public VideoPlayer[] VideoResources = new VideoPlayer[2];
    public string[] VideoResourcesNames = new string[2];
    int lastInd = -1;
    public bool isPlaying = false;
    public bool pausedFromUI = false;

    private void Start()
    {
        MovieManagerobj = this;
        VideoResourcesNames[0] = "The making of Chevrolet 1934";
        VideoResourcesNames[1] = "Bertha benz the first driver";
        StopAllVideos();
    }
    public void StopAllVideos()
    {
        foreach (VideoPlayer v in VideoResources)
            v.Stop();
        Screen.SetActive(false);
        isPlaying = false;
        Status.text = "Currently playing - Nothing";
        lastInd = -1;
    }

    public void PlayVideo(int ResourceInd)
    {
        if (lastInd != ResourceInd)
        {
            lastInd = ResourceInd;
            StopAllVideos();
        }
        isPlaying = true;
        Screen.SetActive(true);
        VideoResources[ResourceInd].Play();
        showNavUI.showNavUIObj.HideMovieUI();
        Status.text = VideoResourcesNames[ResourceInd] + " - Playing";
    }

    public void PauseVideo(bool pauseMenu)
    {
        if (lastInd != -1 && isPlaying)
        {
            pausedFromUI = !pauseMenu;
            VideoResources[lastInd].Pause();
            isPlaying = false;
            Status.text = VideoResourcesNames[lastInd] + " - Paused";
        }
    }

    public void ResumeVideo(bool pauseMenu)
    {
        if (lastInd != -1 && !isPlaying)
        {
            if ((!pausedFromUI && pauseMenu) || (pausedFromUI && !pauseMenu))
            {
                Screen.SetActive(true);
                VideoResources[lastInd].Play();
                isPlaying = true;
                Status.text = VideoResourcesNames[lastInd] + " - Playing";
            }    
        }
    }
    public void OnClickBtnPause()
    {
        PauseVideo(false);
    }
    public void OnClickBtnResume()
    {
        ResumeVideo(false);
    }    
    public void OnClickCloseBtn()
    {
        showNavUI.showNavUIObj.HideMovieUI();
    }

    public void OnClickBtnPlay1()
    {
        PlayVideo(0);
    }
    public void OnClickBtnPlay2()
    {
        PlayVideo(1);
    }
}
