using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWindow : MonoBehaviour {

	public BuyPanelManager buyPanelManager;
	public GameObject startHoodWeBought;
	public void Init()
	{
		StartCoroutine(WaitForFrame());
	}
	IEnumerator WaitForFrame()
	{
		yield return null;
		buyPanelManager.EnableBuyPanel(startHoodWeBought);
		buyPanelManager.BuyBakeryInHood();
	}
}
