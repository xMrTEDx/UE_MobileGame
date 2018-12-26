using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasClicker : MonoBehaviour
{
    public Transform bakeriesParent; //Transform pod ktorym (w hierarchi) są tworzone piekarnie na scenie
    public Transform employeesParent; //Transform pod ktorym (w hierarchi) są tworzoni pracownicy na scenie
    public Text dataText; //tekst w ktorym jest wyswietlana aktualna data
    public WindowsManager windowsManager; //obsluga okien 
    public BakeriesUpgradesWindow bakeriesUpgradesWindow;
    public EmployeesUpgradesWindow employeesUpgradesWindow;
    
    public void Init()
    {
        windowsManager.Init();
        bakeriesUpgradesWindow.Init();
        employeesUpgradesWindow.Init();
    }
}
