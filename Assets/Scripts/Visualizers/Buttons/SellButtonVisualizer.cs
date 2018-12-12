using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButtonVisualizer : MonoBehaviour
{

    Text text;
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }
    void Update()
    {
        text.text = "Sprzedaż piekarni" + "\n" +"\n" +
        "kwota zwrotu: " + "\n" +
        ClickerGame.Instance.BakeriesSystem.CostOfNewBakery / 2;
    }
}
