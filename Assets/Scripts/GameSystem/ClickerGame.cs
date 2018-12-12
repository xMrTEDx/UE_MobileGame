using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerGame : Singleton<ClickerGame>
{
    #region private fields
    private ClickerSystems clickerSystems;
    private CoreClickerSystem coreClickerSystem;
    private BakeriesSystem bakeriesSystem;
    private EmployeesSystem employeesSystem;
    private DataSystem dataSystem;
    private GameSettings gameSettings;
    private MainCanvasClicker mainCanvasClicker;
	private EventSystem eventSystem;
    private Levels levels;
    #endregion

    #region public - systems etc.
    public CoreClickerSystem CoreClickerSystem
    {
        get
        {
            return coreClickerSystem;
        }
    }

    public BakeriesSystem BakeriesSystem
    {
        get
        {
            return bakeriesSystem;
        }
    }

    public EmployeesSystem EmployeesSystem
    {
        get
        {
            return employeesSystem;
        }
    }

    public DataSystem DataSystem
    {
        get
        {
            return dataSystem;
        }
    }

    public MainCanvasClicker MainCanvasClicker
    {
        get
        {
            return mainCanvasClicker;
        }
    }

    public GameSettings GameSettings
    {
        get
        {
            return gameSettings;
        }
    }

    
    public EventSystem EventSystem
    {
        get
        {
            return eventSystem;
        }
    }

    public Levels Levels
    {
        get
        {
            return levels;
        }
    }
    #endregion

    void Start()
    {
        InstantiateGame();
        InitAll();
    }

	void InstantiateGame()
	{
		clickerSystems = FindReferenceOrAdd<ClickerSystems>("Systems", GetComponent<Transform>());
        coreClickerSystem = FindReferenceOrLoad<CoreClickerSystem>(clickerSystems.GetComponent<Transform>());
        bakeriesSystem = FindReferenceOrLoad<BakeriesSystem>(clickerSystems.GetComponent<Transform>());
        employeesSystem = FindReferenceOrLoad<EmployeesSystem>(clickerSystems.GetComponent<Transform>());
        dataSystem = FindReferenceOrLoad<DataSystem>(clickerSystems.GetComponent<Transform>());
        gameSettings = FindReferenceOrLoad<GameSettings>(GetComponent<Transform>());
        levels = gameSettings.GetComponent<Levels>();
        mainCanvasClicker = FindObjectOfType<MainCanvasClicker>();
		if(!mainCanvasClicker) Instantiate(Resources.Load("MainCanvasClicker"));
		eventSystem = FindObjectOfType<EventSystem>();
		if(!eventSystem) Instantiate(Resources.Load("EventSystem"));
	}
    void InitAll()
    {
        coreClickerSystem.Init();
        bakeriesSystem.Init();
        employeesSystem.Init();
        dataSystem.Init();
    }

    T FindReferenceOrAdd<T>(String name, Transform parent) where T : Component
    {
        T find = parent.GetComponentInChildren<T>();
        if (find == null)
        {
            GameObject create = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity, parent);
            create.name = name;
            find = create.AddComponent<T>();
        }
        return find;
    }
    T FindReferenceOrLoad<T>(Transform parent)
    {
        T find = parent.GetComponentInChildren<T>();

        if (find == null)
        {
            Type type = typeof(T);
            GameObject create;
            create = (GameObject)Instantiate(Resources.Load(type.FullName), Vector3.zero, Quaternion.identity, parent);
            find = create.GetComponent<T>();
        }
        return find;
    }
}
