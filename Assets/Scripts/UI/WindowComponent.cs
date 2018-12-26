using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WindowComponent : MonoBehaviour {

	//[Header("Parent")]
	private WindowComponent windowParent;
	//[Header("Events")]
	public UnityEvent e_OnEnableWindow;
	public UnityEvent e_OnDisableWindow;
	public void Init()
	{
		windowParent = GetComponentsInParent<WindowComponent>().ToList().FirstOrDefault(x => x != this);
	}
	public void EnableWindow()
	{
		ClickerGame.Instance.MainCanvasClicker.windowsManager.DisableAllWindows();
		EnableParentWindow();
		gameObject.SetActive(true);
		e_OnEnableWindow.Invoke();
	}
	public void DisableWindow()
	{
		gameObject.SetActive(false);
		e_OnDisableWindow.Invoke();
	}
	public void EnableParentWindow()
	{
		if(windowParent)
		{
			windowParent.gameObject.SetActive(true);
			windowParent.EnableParentWindow();
		}
			
	}
}
