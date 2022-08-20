using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPause : MonoBehaviour
{
    public static AutoPause AutoPauseObj;
    public GameObject music;
    public bool musicOn = true;

    void Start()
    {
        AutoPauseObj = this;
        InvokeRepeating("AutoMute", 0, 1.0f);
    }

    void AutoMute()
    {
        if (musicOn)
        {
            try
            {
                if (MovieManager.MovieManagerobj.isPlaying)
                {
                    music.SetActive(false);
                }
                else
                {
                    music.SetActive(true);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
