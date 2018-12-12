using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsVisualizer : MonoBehaviour {

	Text text;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Start()
	{
		text = GetComponent<Text>();
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		text.text = "Kasa: "+GetPointsValue() +" zł";
	}
	string GetPointsValue()
	{
		double points = Math.Round (ClickerGame.Instance.CoreClickerSystem.GamePoints, 2);
		return points.ToString("N2");
	}
}
