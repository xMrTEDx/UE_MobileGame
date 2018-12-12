using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeriesModifier : MonoBehaviour {

	public void BuyNewBakery()
	{
		//TODO sprawdzić czy są pieniądze i zabrać kasę z puli
		ClickerGame.Instance.BakeriesSystem.AddBakery();
	}
	public void SellBakery()
	{
		if(ClickerGame.Instance.BakeriesSystem.RemoveBakery()){
			//TODO dodać pieniądze do puli
		}
	}
	public void LevelUPBakeries()
	{
		ClickerGame.Instance.BakeriesSystem.LevelUP();
	}
}
