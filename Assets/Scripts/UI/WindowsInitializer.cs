using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WindowsInitializer : MonoBehaviour
{

    List<WindowButtonsList> windows;
    public ControlsContainer controlsContainer; //contain UI prefabs like buttons etc.
    [Space]
    public List<WindowButtonsList> windowsStack;

    void Start()
    {
        Init();
    }
    public void Init()
    {
        windows = GetComponentsInChildren<WindowButtonsList>().ToList();

        if (windows != null && windows.Count > 0)
            windowsStack.Add(windows[0]);

        foreach (var window in windows) //initialize all windows
        {
            if (window.GetComponent<ButtonsList>())
            {
                ButtonsList buttonList = window.GetComponent<ButtonsList>();

                foreach (var button in buttonList.buttons)
                {
                    GameObject instantiateControl = controlsContainer.InstantiateControl<ButtonComponent>(button.buttonText, buttonList.buttonsParent);

                    if (instantiateControl)
                        instantiateControl.GetComponent<ButtonComponent>().onClick.AddListener(() =>
                       {
                           button.e_OnClick.Invoke();
                       });
                }
            }
        }
        StartCoroutine(WaitForFrame());
    }
    IEnumerator WaitForFrame()
    {
        yield return null;
        HideAllWindows();
    }
    public void HideAllWindows()
    {
        foreach (var window in windows)
        {
             window.gameObject.SetActive(false); //hide all windows
        }
        windows[0].EnableWindow(); //show main window
    }
    public void AddWindowToStack(string windowID)
    {
        Type windowType = GetWindowType(windowID);
        if (windowType != null)
        {
            WindowButtonsList windowToAdd = null;
            foreach (var item in windows)
                if (item.GetComponent(windowType))
                    windowToAdd = item;

            if (windowToAdd)
            {
				if (windows.Count > 0)
					windowsStack.Last().DisableWindow();
                if (windowToAdd)
                    windowsStack.Add(windowToAdd);
                windowsStack.Last().EnableWindow();
            }
        }
    }
    public void RemoveWindowFromStack()
    {
        if (windowsStack.Count > 0)
        {
            windowsStack.Last().DisableWindow();
            windowsStack.Remove(windowsStack.Last());
        }
        if (windowsStack.Count > 0)
            windowsStack.Last().EnableWindow();
    }
    public Type GetWindowType(string windowID)
    {
        switch (windowID)
        {
            case "MW":
                return typeof(MainWindow);
			// case "PMW":
            //     return typeof(PauseMainWindow);
            case "SW":
                return typeof(SettingsWindow);
            case "GW":
                return typeof(GraphicWindow);
            case "AW":
                return typeof(AudioWindow);
            case "CW":
                return typeof(CreditsWindow);
            default:
                return null;
        }
    }
}
