using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesModifier : MonoBehaviour
{
    public void HireEmployee()
    {
        if (ClickerGame.Instance.EmployeesSystem.CanHireEmployee)
        {
            if (ClickerGame.Instance.PointsSystem.BuySomething(ClickerGame.Instance.EmployeesSystem.CostOfNewEmployee))
                ClickerGame.Instance.EmployeesSystem.HireEmployee();

            // dodac wynagrodzenie dla pracownika kasowane co miesiac
        }
    }
    public void FireEmployee()
    {
        if (ClickerGame.Instance.EmployeesSystem.FireEmployee())
        {
            //usunac wynagrodzenie pracownika
        }
    }
    
}
