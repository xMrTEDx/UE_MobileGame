using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeriesModifier : MonoBehaviour {

	public void BuyNewBakery()
	{
		//TODO sprawdzić czy są pieniądze i zabrać kasę z puli
		BakeriesSystem.Instance.AddBakery();
	}
	public void SellBakery()
	{
		if(BakeriesSystem.Instance.RemoveBakery()){
			//TODO dodać pieniądze do puli
		}
	}
}
