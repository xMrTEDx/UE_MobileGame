using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AutoPointsModifier))]
[HelpURL("https://docs.google.com/document/d/17IFCpLcMuCVeaXV2bncfuURQZDPa9sldfySxvun7Oz4/edit")]
public class Bakery : MonoBehaviour
{
    //skrypt dołączony jako komponent do każdej piekarni
    private List<Employee> employeesInTheBakery = new List<Employee>();
    private float bakeryAttractiveness = 0;
    public List<Employee> EmployeesInTheBakery
    {
        get
        {
            return employeesInTheBakery;
        }
    }
    public float BakeryAttractiveness
    {
        get
        {
            return bakeryAttractiveness;
        }
    }
    AutoPointsModifier autoPointsModifier;

    void Awake()
    {
        autoPointsModifier = GetComponent<AutoPointsModifier>();
    }

    public bool CanAddEmployee() //zwraca czy jest miejce w piekarni
    {
        return employeesInTheBakery.Count < ClickerGame.Instance.BakeriesSystem.NumberOfWorkPlace ? true : false;
    }
    public bool AddEmployee(Employee employee) //dodaje pracownika do piekarni (pracownik podany w parametrze)
    {
        if (employeesInTheBakery.Count < ClickerGame.Instance.BakeriesSystem.NumberOfWorkPlace)
        {
            employeesInTheBakery.Add(employee);
            RecalculateAutoPoints();
            return true;
        } else return false;
    }
    public bool RemoveEmployee() //usuwa ostatniego pracownika z piekarni
    {
        if (employeesInTheBakery.Count > 0)
        {
            Destroy(employeesInTheBakery.Last().gameObject);
            employeesInTheBakery.Remove(employeesInTheBakery.Last());
            RecalculateAutoPoints();
            return true;
        } else return false;
    }
    public void DestroyBakery() //usuwa wszystkich pracownikow i niszczy piekarnie
    {
        int EmployeesCount = employeesInTheBakery.Count;
        for(int i=0;i<EmployeesCount;i++)
        {
            RemoveEmployee();
        }
        Destroy(gameObject);
    }
    public void RecalculateAutoPoints() //przechodzi przez kazdego pracownika i wylicza ich produktywnosc
    {
        float newAutoPointsValue = 0;
        foreach (var employee in employeesInTheBakery)
        {
            newAutoPointsValue += ClickerGame.Instance.GameSettings.employeesSettings.maxPoints * ((employee.ExperienceProductivity + ClickerGame.Instance.EmployeesSystem.CurrentTrainingProductivity) / 100); //max points * productivity
        }
        autoPointsModifier.ChangeAutoPointsValue(newAutoPointsValue);

    } //TODO wykonywac po szkoleniach i co jakis czas po zdobywaniu doswiadczenia w pracy

}
