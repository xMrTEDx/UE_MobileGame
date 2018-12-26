using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Window : MonoBehaviour {

	//[Header("Parent")]
	private Window windowParent;
	//[Header("Events")]
	public UnityEvent e_OnEnableWindow;
	public UnityEvent e_OnDisableWindow;
	public void Init()
	{
		windowParent = GetComponentsInParent<Window>().ToList().FirstOrDefault(x => x != this);
		// chce uzyskac rodzica z komponentem Window
		// GetComponentInParent zwraca też TEN obiekt, gdyż on też zawiera komponent Window
		// dlatego pobieram wszystkich rodziców i wybieram pierwszego który jest różny od TEGO obiektu
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
			windowParent.EnableWindow();
			windowParent.EnableParentWindow();
		}
			
	}
}
