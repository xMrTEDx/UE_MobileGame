using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/BakeryUpgrade")]
public class BakeryUpgrade : ScriptableObject
{

    public int cost; // koszt ulepszenia
    [TextArea(5,20)]
    public string description;  //opis ulepszenia pokazywany graczowi
    public int additionalWorkPlaces; // liczba dodatkowych miejsc pracy w każdej piekarni
    public float mnoznikPunktow = 1f; // mnoznik punktow za ulepszenie (w stylu: ulepszono sprzęt w piekrani -> wydajnosc rosnie)
    public MnoznikCzasowy[] mnoznikCzasowy;

	[System.Serializable]
	public class MnoznikCzasowy
	{
		public float mnoznikPunktowCzasowy = 1f;
    	public int sekundTrwaniaMnoznika = 10;
	}
}
