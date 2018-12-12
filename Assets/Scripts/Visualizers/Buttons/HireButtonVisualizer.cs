using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireButtonVisualizer : MonoBehaviour {

	Text text;
	void Start () {
		text = GetComponentInChildren<Text>();
	}
	void Update()
	{
		text.text="Zatrudnienie nowego pracownika" +"\n" +"\n" +
		"koszt rekrutacji: " +"\n" +
		ClickerGame.Instance.EmployeesSystem.CostOfNewEmployee +"\n" +
		"wynagrodzenie miesięczne: " +"\n" +
		ClickerGame.Instance.EmployeesSystem.RentOfNewEmployee;
	}
}
