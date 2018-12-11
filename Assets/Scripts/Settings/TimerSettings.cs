using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Timer")]
public class TimerSettings : ScriptableObject
{
    [Header("Czas Timera dodawania punktow")]
    public float TimeInterval = 1;
}
