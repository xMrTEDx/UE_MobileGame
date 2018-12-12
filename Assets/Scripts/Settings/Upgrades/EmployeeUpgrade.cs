using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/EmployeeUpgrade")]
public class EmployeeUpgrade : ScriptableObject {

	public int cost; // koszt ulepszenia
	[TextArea]
	public string description; //opis ulepszenia pokazywany graczowi
	public float trainingProductivity;
	public MnoznikCzasowy[] mnoznikCzasowy;

	[System.Serializable]
	public class MnoznikCzasowy
	{
		public float mnoznikPunktowCzasowy = 1f;
    	public int sekundTrwaniaMnoznika = 10;
	}
}
