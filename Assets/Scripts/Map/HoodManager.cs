using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoodManager : MonoBehaviour {

    //------------------------------------------- Trzeba zrobić grafiki każdej dzielnicy i jakiegoś fajnego znacznika ---------------------------------------------


    //Po zaznaczeniu danej dzielnicy, wyskakuje panel kupna
    //Po kupnie piekarni w danej dzielnicy, piekarnia się kupuje i hoodName zostaje przypisany do tej konkretnej piekarni.
    //markersAmount zwiększa się, by mieć indeks Listy piekarni oraz ilość już rozstawionych piekarni


    //HOWTO:
    //Do Image danej dzielnicy dodajemy EventTrigger OnPointerClick z klasą HoodManager > metoda SelectHood i przypisujemy Image tej danej dzielnicy

    int markersAmount = 1;

    Image selectedHood;

    GameObject buyPanel;

	void Start ()
    {
        buyPanel = GameObject.Find("BuyPanel");
        buyPanel.SetActive(false);
		
	}


    public void BuyBakeryInHood()
    {
        //Sprawdza czy w dzielnicy jest już piekarnia
        if (selectedHood.transform.childCount == 0)
        {

            ////TO NIŻEJ TO FAKTYCZNE KUPIENIE PIEKARNI (skopiowane z BakeriesModifier)
            //if (ClickerGame.Instance.PointsSystem.BuySomething(ClickerGame.Instance.BakeriesSystem.CostOfNewBakery))
            //{
            //    ClickerGame.Instance.BakeriesSystem.AddBakery();
            //    ClickerGame.Instance.BakeriesSystem.Bakeries[markersAmount].hoodName = selectedHood.gameObject.name; //przypisuje nazwę dzielnicy do kupionej piekarni
            //    markersAmount++;

            //    //TUTAJ WSTAWIĆ NIESKOMENTOWANY KOD PONIŻEJ
            //}


            Instantiate(Resources.Load("Marker"), selectedHood.transform.position, selectedHood.transform.rotation, selectedHood.transform);
            Debug.Log(selectedHood.gameObject.name);
            buyPanel.SetActive(false);
        }
        else
            Debug.Log("Posiadasz już piekarnię w tej dzielnicy!");

    }

    public void SelectHood(Image hood)
    {
        if(buyPanel.activeSelf == false)
            buyPanel.gameObject.SetActive(true);
        selectedHood = hood;
    }
}
