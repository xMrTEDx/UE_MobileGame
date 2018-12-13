using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1e54SA8SEdzZv_b1uNvhh8DC1xmB66xVNYXVDytSeBYA/edit")]
public class BakeriesSystem : GamePiece
{
    List<Bakery> _bakeries = new List<Bakery>(); //lista wszystkich piekarn

    private int _numberOfWorkPlace = 1; //liczba miejsc pracy w każdej piekarni (w kazdej jest tyle samo miejsc)

    float _costOfNewBakery;
    public float CostOfNewBakery
    {
        get { return _costOfNewBakery; }
    }
    float _rentOfNewBakery;
    public float RentOfNewBakery
    {
        get { return _rentOfNewBakery; }
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
    }
    public void Ulepsz(BakeryUpgrade upgrade)
    {
        _numberOfWorkPlace += upgrade.additionalWorkPlaces;
        ClickerGame.Instance.CoreClickerSystem.autoPointsManager.DodajMnoznikPunktow(upgrade.mnoznikPunktow);
        if (upgrade.mnoznikCzasowy.Length > 0)
            ClickerGame.Instance.CoreClickerSystem.autoPointsManager.DodajMnoznikPunktow(upgrade.mnoznikCzasowy[0].mnoznikPunktowCzasowy,upgrade.mnoznikCzasowy[0].sekundTrwaniaMnoznika);

        CalculateNewBakeryCosts();
        _bakeries[0].RecalculateAutoPoints();
    }

    void CalculateNewBakeryCosts()
    {
        float buyCosts = ClickerGame.Instance.GameSettings.costsSettings.newBakeryCost + ClickerGame.Instance.GameSettings.costsSettings.newBakeryCost * _numberOfWorkPlace / 4;
        float randomBuy = ClickerGame.Instance.GameSettings.costsSettings.randomBakeryCost;

        float min = buyCosts - buyCosts * randomBuy;
        float max = buyCosts + buyCosts * randomBuy;

        _costOfNewBakery = Random.Range(min, max);

        float rentCosts = ClickerGame.Instance.GameSettings.costsSettings.bakeryRent;
        float randomRent = ClickerGame.Instance.GameSettings.costsSettings.randomBakeryRent;

        min = rentCosts - rentCosts * randomRent;
        max = rentCosts + rentCosts * randomRent;

        _rentOfNewBakery = Random.Range(min, max);
    }
    public void AddWorkPlace() //dodaje miejsce pracy do wszystkich piekarń
    {
        _numberOfWorkPlace++;
    }
    public void AddBakery() //tworzy nową piekranie
    {
        GameObject newBakery = Instantiate(ClickerGame.Instance.GameSettings.bakeriesSettings.bakeryUIprefab, ClickerGame.Instance.MainCanvasClicker.bakeriesParent);
        _bakeries.Add(newBakery.GetComponent<Bakery>());

        CalculateNewBakeryCosts();
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
