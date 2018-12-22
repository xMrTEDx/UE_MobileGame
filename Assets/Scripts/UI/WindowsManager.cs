using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour {

	public WindowsStack[] windowsTree; //drzewo okien
	public List<WindowComponent> searching;

	[System.Serializable]
	public class WindowsStack
	{
		public WindowComponent window;
		public WindowsStack[] childrens;
	}

	public void ShowWindow(WindowComponent windowToShow)
	{
		List<WindowComponent> searching = FindWindow(windowToShow);
		foreach(var item in searching)
			Debug.Log(item.name);
	}

	private List<WindowComponent> FindWindow(WindowComponent windowToFind) //szuka okna i zwraca całą gałąź: jak do niego dotrzeć
	{
		List<WindowComponent> branch = new List<WindowComponent>();

		foreach(var windowStack in windowsTree) //przedź przez wszystkich rodziców i przeszukaj ich dzieci
		{
			//Debug.Log("szukam w rodzicu: "+ windowStack.window.name);
			List<WindowComponent> searchedBranch = FindWIndowInChildren(windowStack,windowToFind);
			if(searchedBranch.Count > 0)
			{
				branch.AddRange(searchedBranch); //jeśli znaleziono okno to utwórz gałąź
				break;
			}
		}
		return branch;
	}
	private List<WindowComponent> FindWIndowInChildren(WindowsStack stackToExplore, WindowComponent windowToFind)
	{
		List<WindowComponent> branch = new List<WindowComponent>();

		if(windowToFind == stackToExplore.window) //jeśli podany rodzic to nasze szukane okno to je zwróć
		{
			branch.Add(stackToExplore.window);
		}
		else
		{
			foreach(var windowStack in stackToExplore.childrens) //jeśli nie to przeszukaj dzieci
			{
				List<WindowComponent> searchedBranch = FindWIndowInChildren(windowStack,windowToFind);
				if(searchedBranch.Count > 0)
				{
					branch.AddRange(searchedBranch);
					break;
				}
					
			}
		}
		return branch;
	}
}
