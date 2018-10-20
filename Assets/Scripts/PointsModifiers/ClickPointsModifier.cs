using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointsModifier : MonoBehaviour {
	public void ZwiekszLiczbePunktowPrzyKliknieciu(int liczbaDodana)
	{
		CoreClickerSystem.Instance.clickPointsManager.ZwiekszLiczbePunktow(liczbaDodana);
	}
	public void ZwiekszLiczbePunktowPrzyKliknieciu(int liczbaDodana, int czasTrwaniaSekund)
	{
		CoreClickerSystem.Instance.clickPointsManager.ZwiekszLiczbePunktow(liczbaDodana,czasTrwaniaSekund);
	}
	public void DodajMnoznikPunktowPrzyKliknieciu(float mnoznik)
	{
		CoreClickerSystem.Instance.clickPointsManager.DodajMnoznikPunktow(mnoznik);
	}
	public void DodajMnoznikPunktowPrzyKliknieciu(float mnoznik, int czasTrwaniaSekund)
	{
		CoreClickerSystem.Instance.clickPointsManager.DodajMnoznikPunktow(mnoznik,czasTrwaniaSekund);
	}
}
