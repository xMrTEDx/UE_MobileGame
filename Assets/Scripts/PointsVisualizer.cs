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
		text.text = "Punkty: "+CoreClickerSystem.Instance.GamePoints.ToString();
	}
}
