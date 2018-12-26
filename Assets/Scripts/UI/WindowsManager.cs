using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour {

	Window[] _windows;
	public Window startWindow;
	public void Init()
	{
		_windows = GetComponentsInChildren<Window>(true);
		ShowAllWindows();
		InitAllWindows();
		DisableAllWindows();
		
		if(startWindow) startWindow.EnableWindow();
	}

	void ShowAllWindows()
	{
		foreach(var item in _windows)
		{
			item.gameObject.SetActive(true);
		}
	}

	public void DisableAllWindows()
	{
		foreach(var item in _windows)
		{
			item.DisableWindow();
		}
	}
	public void InitAllWindows()
	{
		foreach(var item in _windows)
		{
			item.Init();
		}
	}
}
