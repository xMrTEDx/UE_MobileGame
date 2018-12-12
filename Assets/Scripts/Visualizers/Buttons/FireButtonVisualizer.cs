using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButtonVisualizer : MonoBehaviour {
	Text text;
	void Start () {
		text = GetComponentInChildren<Text>();
	}
	void Update()
	{
		text.text="Zwolnienie pracownika";
	}
}
