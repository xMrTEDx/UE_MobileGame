using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsVisualizer : MonoBehaviour
{

    public Text statsText;

    void Update()
    {
        ClickerGame currentGame = ClickerGame.Instance;
        if (statsText)
        {
            string text =
            "Stats\n\n" +
            "Bakeries count: " + currentGame.BakeriesSystem.Bakeries.Count + "\n" +
            "Bakeries level: " + currentGame.BakeriesSystem.BakeryLevel + "\n" +
            "Number od workplaces in every bakery: " + currentGame.BakeriesSystem.NumberOfWorkPlace + "\n" +
            "Employees count: " + EmployeesNumber() + "\n" +
			"Employees level: " + currentGame.EmployeesSystem.EmployeeLevel + "\n" +
            "Employees training productivity: " + currentGame.EmployeesSystem.CurrentTrainingProductivity + "\n" +
            "Income every interval: " + Income() + "\n" +
            "Points added by click: " + currentGame.CoreClickerSystem.clickPointsManager.LiczbaPunktowPrzyKliknieciu * currentGame.CoreClickerSystem.clickPointsManager.MnoznikPunktowPrzyKliknieciu;

            statsText.text = text;
        }
    }
    int EmployeesNumber()
    {
        int number = 0;
        foreach (var bakery in ClickerGame.Instance.BakeriesSystem.Bakeries)
        {
            foreach (var employee in bakery.EmployeesInTheBakery)
            {
                number++;
            }
        }
        return number;
    }
    float Income()
    {
        return ClickerGame.Instance.CoreClickerSystem.autoPointsManager.LiczbaPunktowWPuli * ClickerGame.Instance.CoreClickerSystem.autoPointsManager.MnoznikPunktowWPuli;
    }
}
