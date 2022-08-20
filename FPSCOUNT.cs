using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCOUNT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateFPSCounter", 0, 1.0f);
    }

    public int avgFrameRate;
    public Text display_Text;

    public void UpdateFPSCounter()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}
