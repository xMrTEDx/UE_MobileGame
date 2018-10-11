using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UI/Controls Container")]
public class ControlsContainer : ScriptableObject {

	public GameObject button;
	public GameObject slider;
	public GameObject toggle;
	//public GameObject carousel;
	public GameObject dropDown;

	public GameObject InstantiateControl<T>(string name, Transform parent) where T : Selectable
	{
		GameObject gameObjectToInstantiate = null;

		if(typeof (T) == typeof (ButtonComponent))
		{
			gameObjectToInstantiate = button;
			gameObjectToInstantiate.GetComponent<ButtonComponent>().text.text = name;
		}
		else if(typeof (T) == typeof (SliderComponent))
		{
			gameObjectToInstantiate = slider;
			gameObjectToInstantiate.GetComponent<SliderComponent>().text.text = name;
		}
		else if(typeof (T) == typeof (ToggleComponent))
		{
			gameObjectToInstantiate = toggle;
			gameObjectToInstantiate.GetComponent<ToggleComponent>().text.text = name;
		}
		else if(typeof (T) == typeof (DropDownComponent))
		{
			gameObjectToInstantiate = dropDown;
			gameObjectToInstantiate.GetComponent<DropDownComponent>().text.text = name;
		}

		gameObjectToInstantiate = Instantiate(gameObjectToInstantiate,Vector3.zero,new Quaternion(0,0,0,0),parent);

		return gameObjectToInstantiate;

	}
}
