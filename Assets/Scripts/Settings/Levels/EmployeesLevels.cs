using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Levels/Employees")]
public class EmployeesLevels : ScriptableObject {

	public EmployeeLevel[] levels;
	[System.Serializable]
	public class EmployeeLevel
	{
		public float trainingProductivity;
	}
}
