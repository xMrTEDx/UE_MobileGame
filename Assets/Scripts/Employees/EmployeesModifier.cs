using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesModifier : MonoBehaviour {

	public void HireEmployee()
	{
		if(EmployeesSystem.Instance.HireEmployee())
		{
			//TODO zabrac kase z puli (za szkolenie pracownika)
		}
	}
	public void FireEmployee()
	{
		if(EmployeesSystem.Instance.FireEmployee())
		{
			//TODO cos tam zrobic po zwolnieniu
		}
	}
}
