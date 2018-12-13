using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[HelpURL("https://docs.google.com/document/d/17Km0x2scTWDCgSQ83Jro8NBujDE-mgXYAoTtgKHoR84/edit")]
public class EmployeesSystem : MonoBehaviour
{
    private int _numberOfEmployees = 0;
    private float _currentTrainingProductivity = 0; //wydajnosc ze szkolen (wspolne dla wszystkich pracownikow)
    public float CurrentTrainingProductivity
    {
        get
        {
            return _currentTrainingProductivity;
        }
        set
        {
            if (value > 60)
                _currentTrainingProductivity = 60;
            else if (value < 0)
                _currentTrainingProductivity = 0;
            else _currentTrainingProductivity = value;

        }
    }
    public int NumberOfEmployees
    {
        get
        {
            return _numberOfEmployees;
        }
    }
    public bool CanHireEmployee
    {
        get
        {
            Bakery bakeryToAddEmployee = FindBakeryWithLowestEmployeeNumber();
            return bakeryToAddEmployee.CanAddEmployee();
        }
    }

    float _costOfNewEmployee;
    public float CostOfNewEmployee
    {
        get { return _costOfNewEmployee; }
    }
    float _rentOfNewEmployee;
    public float RentOfNewEmployee
    {
        get { return _rentOfNewEmployee; }
    }
    public void Init() //uzywac zamiast start
    {
        CalculateNewEmployeeCosts();
    }
    public void Ulepsz(EmployeeUpgrade upgrade)
    {
        _currentTrainingProductivity += upgrade.trainingProductivity;
        if (upgrade.mnoznikCzasowy.Length > 0)
            ClickerGame.Instance.PointsSystem.autoPointsManager.DodajMnoznikPunktow(upgrade.mnoznikCzasowy[0].mnoznikPunktowCzasowy, upgrade.mnoznikCzasowy[0].sekundTrwaniaMnoznika);

        CalculateNewEmployeeCosts();
        ClickerGame.Instance.BakeriesSystem.Bakeries[0].RecalculateAutoPoints();
    }
    void CalculateNewEmployeeCosts()
    {
        float buyCosts = ClickerGame.Instance.GameSettings.costsSettings.newEmployeeCost + 5* _currentTrainingProductivity;
        float randomBuy = ClickerGame.Instance.GameSettings.costsSettings.randomEmployeeCost;

        float min = buyCosts - buyCosts * randomBuy;
        float max = buyCosts + buyCosts * randomBuy;

        _costOfNewEmployee = Random.Range(min, max);

        float rentCosts = ClickerGame.Instance.GameSettings.costsSettings.employeeSalary;
        float randomRent = ClickerGame.Instance.GameSettings.costsSettings.randomEmployeeSalary;

        min = rentCosts - rentCosts * randomRent;
        max = rentCosts + rentCosts * randomRent;

        _rentOfNewEmployee = Random.Range(min, max);
    }
    public bool HireEmployee()
    {
        _numberOfEmployees += 1;
        if(addEmployeeToBakery())
        {
            CalculateNewEmployeeCosts();
            return true;
        }
        return false;
    }
    public bool FireEmployee()
    {
        _numberOfEmployees -= 1;
        return removeEmployeeFromBakery();
    }
    private bool addEmployeeToBakery() //dodaje pracownika do piekarni ktora ma najmniej pracownikow zatrudnionych
    {
        Bakery bakeryToAddEmployee = FindBakeryWithLowestEmployeeNumber();
        if (bakeryToAddEmployee.CanAddEmployee())
        {
            GameObject newEmployee = AddEmployeeToScene();
            if (newEmployee)
                return bakeryToAddEmployee.AddEmployee(newEmployee.GetComponent<Employee>());
        }
        return false;

    }
    private bool removeEmployeeFromBakery() //usuwa pracownika z piekarni ktora ma najwiecej pracownikow zatrudnionych
    {
        Bakery bakeryToRemoveEmployee = FindBakeryWithHighestEmployeeNumber();
        return bakeryToRemoveEmployee.RemoveEmployee();
    }
    public GameObject AddEmployeeToScene()
    {
        return Instantiate(ClickerGame.Instance.GameSettings.employeesSettings.employeeUIprefab, ClickerGame.Instance.MainCanvasClicker.employeesParent);
    }
    private Bakery FindBakeryWithLowestEmployeeNumber()
    {
        List<Bakery> bakeries = ClickerGame.Instance.BakeriesSystem.Bakeries;
        int maxIntValue = int.MaxValue;
        int index = 0;

        for (int i = 0; i < bakeries.Count; i++)
        {
            if (bakeries[i].EmployeesInTheBakery.Count < maxIntValue)
            {
                maxIntValue = bakeries[i].EmployeesInTheBakery.Count;
                index = i;
            }
        }
        return bakeries[index];
    }
    private Bakery FindBakeryWithHighestEmployeeNumber()
    {
        List<Bakery> bakeries = ClickerGame.Instance.BakeriesSystem.Bakeries;
        int minIntValue = int.MinValue;
        int index = 0;

        for (int i = 0; i < bakeries.Count; i++)
        {
            if (bakeries[i].EmployeesInTheBakery.Count > minIntValue)
            {
                minIntValue = bakeries[i].EmployeesInTheBakery.Count;
                index = i;
            }
        }
        return bakeries[index];
    }


}
