using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WindowButtonsList : MonoBehaviour {

	public UnityEvent e_OnEnableWindow;
	public UnityEvent e_OnDisableWindow;
	WindowsInitializer windowsInitializer;
	void Start()
	{
		windowsInitializer = GetComponentInParent<WindowsInitializer>();
	}
	public void EnableWindow()
	{
		gameObject.SetActive(true);
		SelectFirstSelectable();
		e_OnEnableWindow.Invoke();
	}
	public void DisableWindow()
	{
		gameObject.SetActive(false);
		e_OnDisableWindow.Invoke();
	}
	private void SelectFirstSelectable()
	{
		Selectable firstSelectable = GetComponentInChildren<Selectable>();
		if(firstSelectable) firstSelectable.Select();
	}
	public void CloseWindow()
	{
		windowsInitializer.RemoveWindowFromStack();
	}
	public void ShowWindow(string windowID)
	{
		windowsInitializer.AddWindowToStack(windowID);
	}
}
