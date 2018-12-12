using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonVisualizer : MonoBehaviour {

	Text text;
	void Start () {
		text = GetComponentInChildren<Text>();
	}
	void Update()
	{
		text.text="Wynajem nowej piekarni" +"\n" +"\n" +
		"koszt: " +"\n" +
		ClickerGame.Instance.BakeriesSystem.CostOfNewBakery +"\n" +
		"czynsz miesięczny: " +"\n" +
		ClickerGame.Instance.BakeriesSystem.RentOfNewBakery;
	}
}
