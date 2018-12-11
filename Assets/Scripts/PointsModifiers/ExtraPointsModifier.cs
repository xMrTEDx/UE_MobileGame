using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPointsModifier : MonoBehaviour {

	public void AddExtraPoints(float value)
	{
		ClickerGame.Instance.CoreClickerSystem.AddExtraPoints(value);
	}
}
