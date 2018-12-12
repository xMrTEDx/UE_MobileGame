using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakeriesStatsVisualizer : MonoBehaviour {

	Text text;
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = 
		string.Format(
			"Number of workplace in every bakery: "
			+ ClickerGame.Instance.BakeriesSystem.NumberOfWorkPlace.ToString());
	}
}
