using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ClickPoints), typeof(AutoPoints))]
[HelpURL("https://docs.google.com/document/d/1yxwlSyVd2fW_dbF42w3urwPe8BSs63UJk-5A1IX4jJ8/edit")]
public class CoreClickerSystem : GamePiece
{
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

    public void Init() //uzywac zamiast start
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
        _gamePoints = 3000;
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
        _gamePoints = 3000;

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
            yield return new WaitForSeconds(ClickerGame.Instance.GameSettings.timerSettings.TimeInterval);
            AddAutoPoints();
            ClickerGame.Instance.DataSystem.ChangeDay();
            switch (ClickerGame.Instance.DataSystem.GetCurrentDay())
            {
                case 1:
                    Debug.Log("Opłata za czynsz: " + ClickerGame.Instance.BakeriesSystem.Bakeries.Count * 2000);
                    break;
                case 10:
                    Debug.Log("Wypłaty pracownicze: " + ClickerGame.Instance.EmployeesSystem.NumberOfEmployees * 1500);
                    
                    break;
                case 15:
                    Debug.Log("Raty kredytu: ");
                    break;
                default:

                    break;
            }
        }
    }
    #endregion

    public bool BuySomething(float cost)
    {
        if (_gamePoints >= cost)
        {
            _gamePoints -= cost;
            return true;
        }
        else return false;
    }
    public void SellSomething(float cost)
    {
        
    }

    private void AddAutoPoints()
    {
        Debug.Log("Dodano punkty: " + (autoPointsManager.LiczbaPunktowWPuli * autoPointsManager.MnoznikPunktowWPuli));
        _gamePoints += autoPointsManager.LiczbaPunktowWPuli * autoPointsManager.MnoznikPunktowWPuli;
    }
    public void AddClickPoints() //wykonywać po kliknięciu
    {
        _gamePoints += clickPointsManager.LiczbaPunktowPrzyKliknieciu * clickPointsManager.MnoznikPunktowPrzyKliknieciu;
    }

    public void AddExtraPoints(float points) //mozliwosc dodania punktow extra
    {
        _gamePoints += points;
    }
}

