using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Data")]
public class DataSettings : ScriptableObject
{
	[Header("Start Date:")]
	public int day;
	public int month;
	public int year;
}
