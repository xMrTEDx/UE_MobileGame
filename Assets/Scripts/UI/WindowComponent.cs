using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowComponent : MonoBehaviour {

	public void ShowWindow()
	{
		ClickerGame.Instance.MainCanvasClicker.windowsManager.ShowWindow(this);
		//Debug.Log("Clicked button: show window");
	}
}
