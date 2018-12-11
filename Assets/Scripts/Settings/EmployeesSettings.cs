using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Employees")]
public class EmployeesSettings : ScriptableObject
{

    [Header("100% employee productivity")]
    public float maxPoints = 5;
    public GameObject employeeUIprefab;
}
