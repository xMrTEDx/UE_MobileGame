using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeriesModifier : MonoBehaviour
{

    public void BuyNewBakery()
    {
        if (ClickerGame.Instance.PointsSystem.BuySomething(ClickerGame.Instance.BakeriesSystem.CostOfNewBakery)) // sprawdzić czy są pieniądze i zabrać kasę z puli
        {
            ClickerGame.Instance.BakeriesSystem.AddBakery();
            //dodac pobieranie kasy za wynajem piekarni
        }
		else
		{
			Debug.Log("Nie masz kasy na to ziomek");
			//poinformuj gracza ze nie ma siana
		}
    }
    public void SellBakery()
    {
        if (ClickerGame.Instance.BakeriesSystem.RemoveBakery())
        {
            ClickerGame.Instance.PointsSystem.SellSomething(ClickerGame.Instance.BakeriesSystem.CostOfNewBakery / 2);
            // odjac pobieranie kasy za wynajem piekarni
        }
		else
		{
			Debug.Log("Nie można sprzedać ostatniej piekarni mistrzu");
			// poinformuj gracza
		}
    }

}
