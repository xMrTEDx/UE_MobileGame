using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Core Clicker System/Clicker Settings")]
public class ClickerSettings : ScriptableObject {
	[Header("Czas Timera dodawania punktow")]
	public float TimeInterval=1;
}
