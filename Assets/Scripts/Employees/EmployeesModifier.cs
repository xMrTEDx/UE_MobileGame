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
        else
        {
            Prompt.Instance.ShowPrompt("Piekarnie są przepelnione. Nie można zatrudnić nowego pracownika.");
        }
    }
    public void FireEmployee()
    {
        if (ClickerGame.Instance.EmployeesSystem.FireEmployee())
        {
            //usunac wynagrodzenie pracownika
        }
        else
        {
             Prompt.Instance.ShowPrompt("Brak pracownikow do zwolnienia.");
        }
    }
    
}
