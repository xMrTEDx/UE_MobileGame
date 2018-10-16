using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CoreClickerSystem : Singleton<CoreClickerSystem>
{
    [Header("Glowne ustawienia rozgrywki")]
    public ClickerSettings clickerSettings;
    [HideInInspector]
    public ClickPoints clickPointsManager = null; //klasa odpowiedzialna za punkty przez klikanie
    [HideInInspector]
    public AutoPoints autoPointsManager = null; // klasa odpowiedzialna za punkty dodawane automatycznie

    private int _gamePoints = 0; //aktualne punkty w grze
    public int GamePoints
    {
        get
        {
            return _gamePoints;
        }
    }

    private bool _gameIsPlaying = false;
    private bool _pauseGame = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        StartNewGame();
    }

    Coroutine autoPointsClock;

    #region Game Management

    public bool IsPlayMode()
    {
        return _gameIsPlaying;
    }
    public bool IsPause()
    {
        return _pauseGame;
    }

    public void StartNewGame()
    {
        _gameIsPlaying = true;
        ClearGameValues();
        StartClock();
    }
    public void PauseGame()
    {
        _pauseGame = true;
        StopClock();
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        _pauseGame = false;
        StartClock();
        Time.timeScale = 1;
    }
    public void StopGame()
    {
        _gameIsPlaying = false;
        StopClock();
    }
    private void ClearGameValues()
    {
        _gamePoints = 0;
        clickPointsManager = new ClickPoints();
        autoPointsManager = new AutoPoints();
    }

    #endregion

    #region Game's Clock

    private void StartClock()
    {
        autoPointsClock = StartCoroutine(StartAutoPointsClock());
    }
    private void StopClock()
    {
        StopCoroutine(autoPointsClock);
    }
    private IEnumerator StartAutoPointsClock()
    {
        while (_gameIsPlaying)
        {
            yield return new WaitForSeconds(clickerSettings.TimeInterval);
            AddAutoPoints();
        }
    }
    #endregion


    private void AddAutoPoints()
    {
        Debug.Log("Dodano punkty: "+(autoPointsManager.LiczbaPunktowWPuli * autoPointsManager.MnoznikPunktowWPuli));
        _gamePoints += (int)(autoPointsManager.LiczbaPunktowWPuli * autoPointsManager.MnoznikPunktowWPuli);
    }
    public void AddClickPoints() // TODO wykonywać po kliknięciu
    {
        _gamePoints += (int)(clickPointsManager.LiczbaPunktowPrzyKliknieciu * clickPointsManager.MnoznikPunktowPrzyKliknieciu);
    }

    public void AddExtraPoints(int points) //mozliwosc dodania punktow extra
    {
        _gamePoints += points;
    }
}

