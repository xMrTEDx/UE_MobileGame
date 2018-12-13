using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditActions : MonoBehaviour {

	public void OpenCreditWindow(bool mozliwoscWyjscia)
	{
		CreditWindow.Instance.Init(mozliwoscWyjscia);
	}
}
