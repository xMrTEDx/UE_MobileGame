using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Upgrades Container")]
public class UpgradesContainer : ScriptableObject {

	public List<BakeryUpgrade> bakeriesUpgrades = new List<BakeryUpgrade>();
	public List<EmployeeUpgrade> employeesUpgrades = new List<EmployeeUpgrade>();
}
