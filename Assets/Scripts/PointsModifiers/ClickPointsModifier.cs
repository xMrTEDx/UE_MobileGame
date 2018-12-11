using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointsModifier : MonoBehaviour {
	public void ZwiekszLiczbePunktowPrzyKliknieciu(int liczbaDodana)
	{
		ClickerGame.Instance.CoreClickerSystem.clickPointsManager.ZwiekszLiczbePunktow(liczbaDodana);
	}
	public void ZwiekszLiczbePunktowPrzyKliknieciu(int liczbaDodana, int czasTrwaniaSekund)
	{
		ClickerGame.Instance.CoreClickerSystem.clickPointsManager.ZwiekszLiczbePunktow(liczbaDodana,czasTrwaniaSekund);
	}
	public void DodajMnoznikPunktowPrzyKliknieciu(float mnoznik)
	{
		ClickerGame.Instance.CoreClickerSystem.clickPointsManager.DodajMnoznikPunktow(mnoznik);
	}
	public void DodajMnoznikPunktowPrzyKliknieciu(float mnoznik, int czasTrwaniaSekund)
	{
		ClickerGame.Instance.CoreClickerSystem.clickPointsManager.DodajMnoznikPunktow(mnoznik,czasTrwaniaSekund);
	}
}
