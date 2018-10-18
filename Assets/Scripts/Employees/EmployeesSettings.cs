using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Employees/Settings")]
public class EmployeesSettings : ScriptableObject
{

    [Header("max employee points on every interval")]
    public float maxPoints = 5;
}
