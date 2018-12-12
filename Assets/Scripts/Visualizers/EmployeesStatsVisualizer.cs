using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeesStatsVisualizer : MonoBehaviour {

	Text text;
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = 
		string.Format(
			"Employees level: "+ ClickerGame.Instance.EmployeesSystem.EmployeeLevel
			+"\n"
			+"Employees training productivity: "
			+ ClickerGame.Instance.EmployeesSystem.CurrentTrainingProductivity);
	}
}
