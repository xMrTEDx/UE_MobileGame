using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Levels/Bakeries")]
public class BakeriesLevels : ScriptableObject {

	public BakeryLevel[] level;
	[System.Serializable]
	public class BakeryLevel : Upgrade
	{
		public int numberOfWorkPlace;
	}
}
