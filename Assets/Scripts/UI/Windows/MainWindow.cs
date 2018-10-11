﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindow : MonoBehaviour {

	public void StartGame()
	{

	}
	public void ExitGame()
	{
#if UNITY_EDITOR
	UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
	Application.OpenURL(webplayerQuitURL);
#else
	Application.Quit();
#endif
	}
}
