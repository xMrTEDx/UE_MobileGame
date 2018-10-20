using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointsComponent : MonoBehaviour {
	public void Click()
	{
		CoreClickerSystem.Instance.AddClickPoints();
	}
}
