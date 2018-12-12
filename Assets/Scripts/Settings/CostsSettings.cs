using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Costs")]
public class CostsSettings : ScriptableObject {

	public int newBakeryCost; //oplata jednorazowa za nową piekarnie (koszty wyposażenia itp)
	[Range(0,1)]
	public float randomBakeryCost; //widelki oplaty
	public int bakeryRent; //oplata za wynajem
	[Range(0,1)]
	public float randomBakeryRent; //widelki wynajmu

	public int newEmployeeCost; // koszty rekrutacji

	[Range(0,1)]
	public float randomEmployeeCost; //widelki kwoty rekrutacji
	public int employeeSalary; //wynagrodzenie pracownika
	[Range(0,1)]
	public float randomEmployeeSalary; //widelki wynagrodzenia pracownika
}
