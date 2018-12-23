using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanelManager : MonoBehaviour {

    GameObject buyPanel;

    GameObject selectedDistrict;

    int markersAmount = 1;

    private void Awake()
    {
        buyPanel = GameObject.Find("BuyPanel");
        buyPanel.SetActive(false);
    }

    public void EnableBuyPanel(GameObject district)
    {
        if (buyPanel.activeSelf == false)
            buyPanel.SetActive(true);
        selectedDistrict = district;
        Debug.Log("wybrana dzielnica : " + selectedDistrict.name);
    }


    public void BuyBakeryInHood()
    {
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
