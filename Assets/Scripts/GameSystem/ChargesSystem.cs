using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ChargesSystem : MonoBehaviour
{
    List<Credit> credits = new List<Credit>();

    public float TakeCharges()
    {
        float charges = 0;

        switch (ClickerGame.Instance.DataSystem.GetCurrentDate().Day)
        {
            case 1:
                Debug.Log("Opłata za czynsz: " + ClickerGame.Instance.BakeriesSystem.Bakeries.Count * 2000);

                break;
            case 10:
                Debug.Log("Wypłaty pracownicze: " + ClickerGame.Instance.EmployeesSystem.NumberOfEmployees * 1500);

                break;
            case 15:
                charges = PayInstallments();
                Debug.Log("Raty kredytu: " + charges);
                break;
            default:
                break;
        }

        if(charges != 0) ClickerGame.Instance.PointsSystem.PayCharges(charges);
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
            if (c.numberOfInstallments == 0)
            {
                credits.Remove(c);
            }
        }
        return money;
    }
}

