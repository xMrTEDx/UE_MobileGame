using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsInitializer : MonoBehaviour {

	Window[] windows;
	public ControlsContainer controlsContainer; //contain UI prefabs like buttons etc.
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Init();
	}
	public void Init()
	{
		windows = GetComponentsInChildren<Window>();

		foreach(var window in windows) //initialize all windows
		{
			if(window.GetComponent<ButtonsList>())
			{
				ButtonsList buttonsList = window.GetComponent<ButtonsList>();
				
				foreach(var button in buttonsList.buttons)
				{
					GameObject instantiateButton = controlsContainer.InstantiateControl<ButtonComponent>(button.buttonText,buttonsList.buttonsParent);

					if(instantiateButton)
					instantiateButton.GetComponent<ButtonComponent>().onClick.AddListener( () =>
					{
						button.e_OnClick.Invoke();
					});
				}
				
			}
			window.gameObject.SetActive(false); //hide all windows
		}
		windows[0].gameObject.SetActive(true); //show main window
	}
}
