using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointsModifier : MonoBehaviour {
	public void ZwiekszLiczbePunktowPrzyKliknieciu(int liczbaDodana)
	{
		ClickerGame.Instance.PointsSystem.clickPointsManager.ZwiekszLiczbePunktow(liczbaDodana);
	}
	public void ZwiekszLiczbePunktowPrzyKliknieciu(int liczbaDodana, int czasTrwaniaSekund)
	{
		ClickerGame.Instance.PointsSystem.clickPointsManager.ZwiekszLiczbePunktow(liczbaDodana,czasTrwaniaSekund);
	}
	public void DodajMnoznikPunktowPrzyKliknieciu(float mnoznik)
	{
		ClickerGame.Instance.PointsSystem.clickPointsManager.DodajMnoznikPunktow(mnoznik);
	}
	public void DodajMnoznikPunktowPrzyKliknieciu(float mnoznik, int czasTrwaniaSekund)
	{
		ClickerGame.Instance.PointsSystem.clickPointsManager.DodajMnoznikPunktow(mnoznik,czasTrwaniaSekund);
	}
}
