﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quit()
    {
        Application.Quit();
/*#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.quit();
#endif*/
    }
}
