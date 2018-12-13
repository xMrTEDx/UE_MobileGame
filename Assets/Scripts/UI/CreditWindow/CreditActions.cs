using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditActions : MonoBehaviour {

	public void ShowCreditWindow(bool mozliwoscWyjscia)
	{
		CreditWindow.Instance.ShowCreditWindow(mozliwoscWyjscia);
	}
}
