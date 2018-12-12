using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Levels/Employees")]
public class EmployeesLevels : ScriptableObject {

	public EmployeeLevel[] level;
	[System.Serializable]
	public class EmployeeLevel : Upgrade
	{
		public float trainingProductivity;
	}
}
