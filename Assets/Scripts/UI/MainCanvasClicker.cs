using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasClicker : MonoBehaviour
{
    [Header("-------- Windows references --------"), Space]
    public GameObject mapWindow;
    public GameObject bakeriesWindow;
    public GameObject EmployeesWindow;
    public GameObject statsWindow;
    [Space, Header("-------- Other references --------"), Space]

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
        mapWindow.GetComponent<CameraPositionController>().SetCameraParameters();
        mapWindow.GetComponent<MapWindow>().Init();
    }
}
