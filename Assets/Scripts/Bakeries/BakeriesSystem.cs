using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1e54SA8SEdzZv_b1uNvhh8DC1xmB66xVNYXVDytSeBYA/edit")]
public class BakeriesSystem : GamePiece
{
    List<Bakery> _bakeries = new List<Bakery>(); //lista wszystkich piekarn

    private int _numberOfWorkPlace = 0; //liczba miejsc pracy w każdej piekarni (w kazdej jest tyle samo miejsc)


    private byte _bakeryLevel = 0;      //poziom piekarni (wszystkie upgrade'ują się jednoczesnie)

    public byte BakeryLevel
    {
        get
        {
            return _bakeryLevel;
        }
    }

    public int NumberOfWorkPlace
    {
        get
        {
            return _numberOfWorkPlace;
        }
    }
    public List<Bakery> Bakeries
    {
        get
        {
            return _bakeries;
        }
    }
    public void Init() //uzywac zamiast start
    {
        AddBakery();
        _numberOfWorkPlace = ClickerGame.Instance.Levels.bakeriesLevels.level[0].numberOfWorkPlace;
    }

    public void LevelUP()
    {
        if (_bakeryLevel + 1 < ClickerGame.Instance.Levels.bakeriesLevels.level.Length)
        {
            if (ClickerGame.Instance.CoreClickerSystem.GamePoints >= ClickerGame.Instance.Levels.bakeriesLevels.level[_bakeryLevel + 1].value)
            {
                _bakeryLevel++;
                _numberOfWorkPlace = ClickerGame.Instance.Levels.bakeriesLevels.level[_bakeryLevel].numberOfWorkPlace;

                ClickerGame.Instance.CoreClickerSystem.BuyUpgrade(ClickerGame.Instance.Levels.bakeriesLevels.level[_bakeryLevel]); //zabiera kase za upgrade

                 Debug.Log("ulepszono");
            }
            else
            {
                // wyswietl uzytkownikowi ze nie ma kasy na upgrade
                Debug.Log("Nie masz kasy na ten upgrade leszczu");
            }
        }
        else
        {
            // wyswietl uzytkownikowi ze max level
             Debug.Log("max level");
        }
    }

    public void AddWorkPlace() //dodaje miejsce pracy do wszystkich piekarń
    {
        _numberOfWorkPlace++;
    }
    public void AddBakery() //tworzy nową piekranie
    {
        GameObject newBakery = Instantiate(ClickerGame.Instance.GameSettings.bakeriesSettings.bakeryUIprefab, ClickerGame.Instance.MainCanvasClicker.bakeriesParent);
        _bakeries.Add(newBakery.GetComponent<Bakery>());
    }
    public bool RemoveBakery() //usuwa piekarnie
    {
        if (_bakeries.Count > 1) //nie mozna usunac ostatniej piekarni
        {
            _bakeries.Last().DestroyBakery();
            _bakeries.Remove(_bakeries.Last());
            return true;
        }
        return false;
    }

}
