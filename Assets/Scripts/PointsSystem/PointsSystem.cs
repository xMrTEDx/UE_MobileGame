using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ClickPoints), typeof(AutoPoints))]
[HelpURL("https://docs.google.com/document/d/1yxwlSyVd2fW_dbF42w3urwPe8BSs63UJk-5A1IX4jJ8/edit")]
public class PointsSystem : MonoBehaviour
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
    public void Init() //uzywac zamiast start
    {
        clickPointsManager = GetComponent<ClickPoints>();
        autoPointsManager = GetComponent<AutoPoints>();
    }

    public bool BuySomething(float cost)
    {
        if (_gamePoints >= cost)
        {
            _gamePoints -= cost;
            return true;
        }
        else return false;
    }
    public void PayCharges(float value)
    {
        _gamePoints -= value;
    }
    public void SellSomething(float cost)
    {
        _gamePoints += cost;
    }
    public void AddPoints(float money)
    {
        _gamePoints += money;
    }

    public void RemovePoints(float money)
    {
        _gamePoints = money;
    }


    public void AddAutoPoints()
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

