using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanelManager : MonoBehaviour {

    public GameObject buyPanel;
    public Text selectedDistrictText;


    GameObject selectedDistrict;

    int markersAmount = 1;


    public void EnableBuyPanel(GameObject district)
    {
        if (buyPanel.activeSelf == false)
            buyPanel.SetActive(true);
        selectedDistrict = district;
        selectedDistrictText.text = "Selected district: " + selectedDistrict.name;
    }

    public void RemoveBakeryFromHood()
    {
        if (selectedDistrict.transform.childCount > 0)
        {
            if (ClickerGame.Instance.BakeriesSystem.RemoveBakery(selectedDistrict.name))
            {
                Debug.Log("sprzedano piekarnie");
                ClickerGame.Instance.PointsSystem.SellSomething(ClickerGame.Instance.BakeriesSystem.CostOfNewBakery / 2);

                Destroy(selectedDistrict.transform.GetChild(0).gameObject); //usuwanie znacznika
                selectedDistrict.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f);
                markersAmount--;
            }
            else
            {
                Debug.Log("Nie można sprzedać ostatniej piekarni mistrzu");
                // poinformuj gracza
            }
        }
    }


    public void BuyBakeryInHood()
    {
        Debug.Log(selectedDistrict.GetComponent<SpriteRenderer>().material.color);
        //Sprawdza czy w dzielnicy jest już piekarnia
        if (selectedDistrict.transform.childCount == 0)
        {

            //TO NIŻEJ TO FAKTYCZNE KUPIENIE PIEKARNI (skopiowane z BakeriesModifier)
            if (ClickerGame.Instance.PointsSystem.BuySomething(ClickerGame.Instance.BakeriesSystem.CostOfNewBakery))
            {
                ClickerGame.Instance.BakeriesSystem.AddBakery();

                ClickerGame.Instance.BakeriesSystem.Bakeries[markersAmount].hoodName = selectedDistrict.gameObject.name; //przypisuje nazwę dzielnicy do kupionej piekarni

                Instantiate(Resources.Load("Marker"), selectedDistrict.transform.position, selectedDistrict.transform.rotation, selectedDistrict.transform);


                string nazwa = "Piekarnia w " + selectedDistrict.gameObject.name;
                ClickerGame.Instance.BakeriesSystem.Bakeries[markersAmount].gameObject.GetComponentInChildren<Text>().text = nazwa;
                selectedDistrict.GetComponent<SpriteRenderer>().material.color = Color.green;


                buyPanel.SetActive(false);

                markersAmount++;
            }


        }
        else
            Debug.Log("Posiadasz już piekarnię w tej dzielnicy!");
    }



}
