using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [Header("Main Systems Settings")]
    public TimerSettings timerSettings;
    public BakeriesSettings bakeriesSettings;
    public EmployeesSettings employeesSettings;
    public DataSettings dataSettings;
    [Header("Game Upgrades")]
    public UpgradesContainer gameUpgrades;
    [Header("Costs Settings")]
    public  CostsSettings costsSettings;
}
