using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsVisualizer : MonoBehaviour {

	public Text statsText;

	void Update()
	{
		if(statsText)
		{
			string text = 
			"Stats\n\n"+
			"Bakeries count: "+BakeriesSystem.Instance.Bakeries.Count+"\n"+
			"Number od workplaces in every bakery: "+BakeriesSystem.Instance.NumberOfWorkPlace+"\n"+
			"Employees count: "+EmployeesNumber()+"\n"+
			"Employees training productivity: "+EmployeesSystem.Instance.TrainingProductivity+"\n"+
			"Income every interval: "+Income()+"\n"+
			"Points added by click: "+CoreClickerSystem.Instance.clickPointsManager.LiczbaPunktowPrzyKliknieciu*CoreClickerSystem.Instance.clickPointsManager.MnoznikPunktowPrzyKliknieciu;

			statsText.text = text;
		}
	}
	int EmployeesNumber()
	{
		int number =0;
		foreach(var bakery in BakeriesSystem.Instance.Bakeries)
		{
			foreach(var employee in bakery.EmployeesInTheBakery)
			{
				number++;
			}
		}
		return number;
	}
	float Income()
	{
		return CoreClickerSystem.Instance.autoPointsManager.LiczbaPunktowWPuli * CoreClickerSystem.Instance.autoPointsManager.MnoznikPunktowWPuli;
	}
}
