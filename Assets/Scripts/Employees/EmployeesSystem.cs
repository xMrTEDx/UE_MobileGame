using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[HelpURL("https://docs.google.com/document/d/17Km0x2scTWDCgSQ83Jro8NBujDE-mgXYAoTtgKHoR84/edit")]
public class EmployeesSystem : MonoBehaviour
{
    private float _currentTrainingProductivity = 0; //wydajnosc ze szkolen (wspolne dla wszystkich pracownikow)
    private byte _CurrentEmployeeLevel = 0;

    public byte EmployeeLevel
    {
        get
        {
            return _CurrentEmployeeLevel;
        }
    }
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
    public void Init() //uzywac zamiast start
    {
        _currentTrainingProductivity = ClickerGame.Instance.Levels.employeesLevels.level[0].trainingProductivity;
    }
    public bool HireEmployee()
    {
        return addEmployeeToBakery();
    }
    public bool FireEmployee()
    {
        return removeEmployeeFromBakery();
    }
    public void LevelUPEmployees()
    {
        if (_CurrentEmployeeLevel + 1 < ClickerGame.Instance.Levels.bakeriesLevels.level.Length)
        {
            if (ClickerGame.Instance.CoreClickerSystem.GamePoints >= ClickerGame.Instance.Levels.bakeriesLevels.level[_CurrentEmployeeLevel + 1].value)
            {
                _CurrentEmployeeLevel++;
                _currentTrainingProductivity = ClickerGame.Instance.Levels.employeesLevels.level[_CurrentEmployeeLevel].trainingProductivity;

                ClickerGame.Instance.CoreClickerSystem.BuyUpgrade(ClickerGame.Instance.Levels.bakeriesLevels.level[_CurrentEmployeeLevel]); //zabiera kase za upgrade
                Debug.Log("ulepszono");
            }
            else
            {
                // wyswietl uzytkownikowi ze nie ma kasy na upgrade
                Debug.Log("Nie masz kasy na ten upgrade leszczu");
            }
        }
        else
        {
            // wyswietl uzytkownikowi ze max level
            Debug.Log("max level");
        }
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
