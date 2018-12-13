using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditActions : MonoBehaviour {

	public void OpenCreditWindow()
	{
		CreditWindow.Instance.Init();
	}
}
