using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Levels/Bakeries")]
public class BakeriesLevels : ScriptableObject {

	public BakeryLevel[] levels;
	[System.Serializable]
	public class BakeryLevel
	{
		public float autoPoints;
		public float autoPointsMultipler;
		public int numberOfWorkPlace;
	}
}
