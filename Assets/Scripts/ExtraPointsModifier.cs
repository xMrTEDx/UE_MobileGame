using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPointsModifier : MonoBehaviour {

	public void AddExtraPoints(int value)
	{
		CoreClickerSystem.Instance.AddExtraPoints(value);
	}
}
