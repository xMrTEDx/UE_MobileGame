using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ClickPoints), typeof(AutoPoints))]
[HelpURL("https://docs.google.com/document/d/1yxwlSyVd2fW_dbF42w3urwPe8BSs63UJk-5A1IX4jJ8/edit")]
public class CoreClickerSystem : Singleton<CoreClickerSystem>
{
    [Header("Glowne ustawienia rozgrywki")]
    public ClickerSettings clickerSettings; //asset przechowujacy ustawienia
    [HideInInspector]
    public ClickPoints clickPointsManager = null; //klasa odpowiedzialna za punkty przez klikanie
    [HideInInspector]
    public AutoPoints autoPointsManager = null; // klasa odpowiedzialna za punkty dodawane automatycznie

    private float _gamePoints = 0; //aktualne punkty w grze
    public float GamePoints
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
        clickPointsManager = GetComponent<ClickPoints>();
        autoPointsManager = GetComponent<AutoPoints>();
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

        clickPointsManager.ResetValues();
        autoPointsManager.ResetValues();
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
        Debug.Log("Dodano punkty: " + (autoPointsManager.LiczbaPunktowWPuli * autoPointsManager.MnoznikPunktowWPuli));
        _gamePoints += autoPointsManager.LiczbaPunktowWPuli * autoPointsManager.MnoznikPunktowWPuli;
    }
    public void AddClickPoints() //wykonywać po kliknięciu
    {
        _gamePoints += clickPointsManager.LiczbaPunktowPrzyKliknieciu * clickPointsManager.MnoznikPunktowPrzyKliknieciu;
    }

    public void AddExtraPoints(int points) //mozliwosc dodania punktow extra
    {
        _gamePoints += points;
    }
}

