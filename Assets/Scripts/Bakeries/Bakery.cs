using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AutoPointsComponent))]
[HelpURL("https://docs.google.com/document/d/17IFCpLcMuCVeaXV2bncfuURQZDPa9sldfySxvun7Oz4/edit")]
public class Bakery : MonoBehaviour
{
    private List<Employee> employeesInTheBakery = new List<Employee>();
    public List<Employee> EmployeesInTheBakery
    {
        get
        {
            return employeesInTheBakery;
        }
    }

    public EmployeesSettings employeesSettings;
    AutoPointsComponent autoPointsManager;

    void Awake()
    {
        autoPointsManager = GetComponent<AutoPointsComponent>();
    }

    public bool AddEmployee()
    {
        if (employeesInTheBakery.Count < BakeriesSystem.Instance.NumberOfWorkPlace)
        {
            //TODO dodac pracownika na scenie
            Employee newEmployee = new Employee();
            employeesInTheBakery.Add(newEmployee);
            RecalculateAutoPoints();

            return true;
        } else return false;
    }
    public bool RemoveEmployee()
    {
        if (employeesInTheBakery.Count > 0)
        {
            Destroy(employeesInTheBakery.Last().gameObject);
            employeesInTheBakery.Remove(employeesInTheBakery.Last());
            RecalculateAutoPoints();

            return true;
        } else return false;
    }
    public void RecalculateAutoPoints() //przechodzi przez kazdego pracownika i wylicza ich produktywnosc
    {
        float newAutoPointsValue = 0;
        foreach (var employee in employeesInTheBakery)
        {
            newAutoPointsValue += employeesSettings.maxPoints * ((employee.ExperienceProductivity + EmployeesSystem.Instance.TrainingProductivity) / 100); //max points * productivity
        }
        autoPointsManager.ChangeAutoPointsValue(newAutoPointsValue);

    } //TODO wykonywac po szkoleniach i co jakis czas po zdobywaniu doswiadczenia w pracy

}
