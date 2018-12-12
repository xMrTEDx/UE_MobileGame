using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesModifier : MonoBehaviour
{

    public void HireEmployee()
    {
        if (ClickerGame.Instance.EmployeesSystem.HireEmployee())
        {
            //TODO zabrac kase z puli (za szkolenie pracownika)
        }
    }
    public void FireEmployee()
    {
        if (ClickerGame.Instance.EmployeesSystem.FireEmployee())
        {
            //TODO cos tam zrobic po zwolnieniu
        }
    }
    public void LevelUP()
    {
        ClickerGame.Instance.EmployeesSystem.LevelUPEmployees();
    }
}
