using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainWindow : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene("Clicker");
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
