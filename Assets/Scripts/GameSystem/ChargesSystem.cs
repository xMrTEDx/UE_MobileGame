using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ChargesSystem : MonoBehaviour
{
    List<Credit> credits;
    public Contracts contract;
    public float basicRent;

    public void Init()
    {
        credits = new List<Credit>();
        contract = new Contracts();
        basicRent = 2000;
    }

    public float TakeCharges()
    {
        float charges = 0;

        switch (ClickerGame.Instance.DataSystem.GetCurrentDate().Day)
        {
            case 1:
                Debug.Log("Opłata za czynsz: " + ClickerGame.Instance.BakeriesSystem.Bakeries.Count * 2000);

                break;
            case 10:
                ClickerGame.Instance.EmployeesSystem.ImproveExperienceProduktivity();
                contract.calculateCosts();
                charges = contract.OverallCosts * ClickerGame.Instance.EmployeesSystem.NumberOfEmployees;
                Debug.Log("Wypłaty pracownicze: " + charges);
                break;
            case 15:
                charges = PayInstallments();
                Debug.Log("Raty pożyczek: " + charges);
                break;
            default:
                break;
        }

        if(charges != 0) ClickerGame.Instance.PointsSystem.RemovePoints(charges);
        return charges;
    }

    public bool TakeCredit(int moneyToGet, int installments)
    {
        if (credits.Count < 3)
        {
            ClickerGame.Instance.PointsSystem.AddPoints(moneyToGet);
            credits.Add(new Credit(moneyToGet, installments));
            return true;
        }
        else
        {
            Debug.Log("Gdzie tam biedaku, spłać poprzednie kredyty!");
            return false;
        }
    }

    public float PayInstallments()
    {
        float money = 0;
        foreach (Credit c in credits)
        {
            money += c.installment;
            c.PayInstallment();
        }
        for (int i = 0; i < credits.Count; i++)
        {
            if(credits[i].numberOfInstallments == 0)
            {
                credits.RemoveAt(i);
                i--;
            }
        }
        return money;
    }

    public float PayAllInstallments()
    {
        float money = 0;
        foreach(Credit c in credits)
        {
            money += (float)(c.numberOfInstallments * 0.9) * c.installment;
        }
        foreach (Credit c in credits)
        {
            credits.Remove(c);
        }

        if(money > ClickerGame.Instance.PointsSystem.GamePoints)
        {
            money = 0;
            Debug.Log("Nie masz tyle pieniędzy");
        }

        return money;
    }
}

