using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[HelpURL("https://docs.google.com/document/d/17Km0x2scTWDCgSQ83Jro8NBujDE-mgXYAoTtgKHoR84/edit")]
public class EmployeesSystem : Singleton<EmployeesSystem>
{
    public EmployeesAsset employeeAsset;
    public Transform employeesParent;
    private float _trainingProductivity = 0; //wydajnosc ze szkolen (wspolne dla wszystkich pracownikow)
    public float TrainingProductivity
    {
        get
        {
            return _trainingProductivity;
        }
        set
        {
            if (value > 60)
                _trainingProductivity = 60;
            else if (value < 0)
                _trainingProductivity = 0;
            else _trainingProductivity = value;

        }
    }
    public EmployeesSettings employeesSettings;
    public bool HireEmployee()
    {
        return addEmployeeToBakery();
    }
    public bool FireEmployee()
    {
        return removeEmployeeFromBakery();
    }
    private bool addEmployeeToBakery() //dodaje pracownika do piekarni ktora ma najmniej pracownikow zatrudnionych
    {
        Bakery bakeryToAddEmployee = FindBakeryWithLowestEmployeeNumber();
        if(bakeryToAddEmployee.CanAddEmployee())
        {
            GameObject newEmployee = AddEmployeeToScene();
            if(newEmployee)
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
        return Instantiate(employeeAsset.EmployeeGameObject,employeesParent);
    }
    private Bakery FindBakeryWithLowestEmployeeNumber()
    {
        List<Bakery> bakeries = BakeriesSystem.Instance.Bakeries;
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
        List<Bakery> bakeries = BakeriesSystem.Instance.Bakeries;
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
