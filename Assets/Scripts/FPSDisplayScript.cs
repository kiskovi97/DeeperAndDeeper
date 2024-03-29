﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplayScript : MonoBehaviour
{
    float timeA;
    public int fps;
    public int lastFPS;
    public GUIStyle textStyle;
    // Use this for initialization
    void Start()
    {
        timeA = Time.timeSinceLevelLoad;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.timeSinceLevelLoad+" "+timeA);
        if (Time.timeSinceLevelLoad - timeA <= 1)
        {
            fps++;
        }
        else
        {
            lastFPS = fps + 1;
            timeA = Time.timeSinceLevelLoad;
            fps = 0;
        }
    }
    void OnGUI()
    {
#if UNITY_EDITOR
#else
        if (Debug.isDebugBuild)
        {
             GUI.Label(new Rect(5, 5, 30, 30), "" + lastFPS, textStyle);
        }
#endif
    }
}