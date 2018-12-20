using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Contracts
{
    private string contractType = "UZ";
    private float overallCosts = 0;
    public float OverallCosts
    {
        get
        {
            return overallCosts;
        }
    }

    public void calculateCosts()
    {
        float basicSalary = ClickerGame.Instance.EmployeesSystem.Salary;
        if (contractType == "UoP")
        {
            overallCosts = basicSalary + basicSalary * 0.65f;
        }
        else
        {
            overallCosts = basicSalary + basicSalary * 0.58f;
            Debug.Log(overallCosts);
            Debug.Log(basicSalary);
        }
    }

    public void ChangeContract()
    {
        if(contractType == "UoP")
        {
            contractType = "UZ";
        }
        else
        {
            contractType = "UoP";
        }
    }
}

