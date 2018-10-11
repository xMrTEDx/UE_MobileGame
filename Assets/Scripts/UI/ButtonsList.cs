using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonsList : MonoBehaviour {

	public ButtonTerm[] buttons;
	public Transform buttonsParent;


	[System.Serializable]
	public class ButtonTerm
	{
		public string buttonText;

		public UnityEvent e_OnClick;
	}
}
