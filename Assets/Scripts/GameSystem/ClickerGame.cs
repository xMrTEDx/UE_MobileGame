using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerGame : Singleton<ClickerGame>
{
    #region private fields
    private ClickerSystems clickerSystems;
    private PointsSystem coreClickerSystem;
    private BakeriesSystem bakeriesSystem;
    private EmployeesSystem employeesSystem;
    private DataSystem dataSystem;
    private ChargesSystem chargesSystem;
    private GameSettings gameSettings;
    private MainCanvasClicker mainCanvasClicker;
    private EventSystem eventSystem;
    #endregion

    #region public - systems etc.
    public PointsSystem CoreClickerSystem
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

    public ChargesSystem ChargesSystem
    {
        get
        {
            return chargesSystem;
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


    #endregion


    private bool _gameIsPlaying = false;
    private bool _pauseGame = false;

    public bool IsPlayMode()
    {
        return _gameIsPlaying;
    }
    public bool IsPause()
    {
        return _pauseGame;
    }

    Coroutine autoPointsClock;

    void Start()
    {
        StartNewGame();
    }



    public void StartNewGame()
    {
        _gameIsPlaying = true;
        if(_pauseGame) ResumeGame();

        DestroySystems();
        
        InstantiateGame();
        InitAll();

        StartClock();
    }
    
    void Init()
    {
        CreditWindow.Instance.ShowCreditWindow(false);
    }


    public void PauseGame()
    {
        _gameIsPlaying = true;
        _pauseGame = true;
        //StopClock();
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        _gameIsPlaying = true;
        _pauseGame = false;
        //StartClock();
        Time.timeScale = 1;
    }
    public void StopGame()
    {
        _gameIsPlaying = false;
        _pauseGame = false;
        //zapisz stan gry
        StopClock();
        DestroySystems();
    }

    #region Game's Clock

    private void StartClock()
    {
        autoPointsClock = StartCoroutine(ClockCourtine());
    }
    private void StopClock()
    {
        StopCoroutine(autoPointsClock);
    }
    private IEnumerator ClockCourtine()
    {
        while (_gameIsPlaying)
        {
            yield return new WaitForSeconds(ClickerGame.Instance.GameSettings.timerSettings.TimeInterval);
            DoClockActions();
        }
    }
    private void DoClockActions() //metody wykonywane co kazdy cykl zegara
    {
        coreClickerSystem.AddAutoPoints();
        ClickerGame.Instance.DataSystem.ChangeDay();
        ClickerGame.Instance.ChargesSystem.TakeCharges(); //wazna kolejnosc! najpierw zmiana dnia, a pozniej pobieranie oplat
    }
    #endregion

    void InstantiateGame()
    {
        clickerSystems = FindReferenceOrAdd<ClickerSystems>("Systems", GetComponent<Transform>());
        coreClickerSystem = FindReferenceOrLoad<PointsSystem>(clickerSystems.GetComponent<Transform>());
        bakeriesSystem = FindReferenceOrLoad<BakeriesSystem>(clickerSystems.GetComponent<Transform>());
        employeesSystem = FindReferenceOrLoad<EmployeesSystem>(clickerSystems.GetComponent<Transform>());
        dataSystem = FindReferenceOrLoad<DataSystem>(clickerSystems.GetComponent<Transform>());
        chargesSystem = FindReferenceOrLoad<ChargesSystem>(clickerSystems.GetComponent<Transform>());
        gameSettings = FindReferenceOrLoad<GameSettings>(GetComponent<Transform>());
        mainCanvasClicker = FindObjectOfType<MainCanvasClicker>();
        if (!mainCanvasClicker) Instantiate(Resources.Load("MainCanvasClicker"));
        eventSystem = FindObjectOfType<EventSystem>();
        if (!eventSystem) Instantiate(Resources.Load("EventSystem"));

        BakeriesUpgradesWindow bakeriesUpgradesWindow = mainCanvasClicker.GetComponentInChildren<BakeriesUpgradesWindow>();
        if (bakeriesUpgradesWindow) bakeriesUpgradesWindow.Init();

        EmployeesUpgradesWindow employeesUpgradesWindow = mainCanvasClicker.GetComponentInChildren<EmployeesUpgradesWindow>();
        if (employeesUpgradesWindow) employeesUpgradesWindow.Init();
    }
    void DestroySystems()
    {
        if(clickerSystems) Destroy(clickerSystems);
        if(coreClickerSystem) Destroy(coreClickerSystem);
        if(bakeriesSystem) Destroy(bakeriesSystem);
        if(employeesSystem) Destroy(employeesSystem);
        if(dataSystem) Destroy(dataSystem);
        if(chargesSystem) Destroy(chargesSystem);
        if(gameSettings) Destroy(gameSettings);
        if(mainCanvasClicker) Destroy(mainCanvasClicker);
        if(eventSystem) Destroy(eventSystem);
    }
    void InitAll()
    {
        Init();
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
