using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1e54SA8SEdzZv_b1uNvhh8DC1xmB66xVNYXVDytSeBYA/edit")]
public class BakeriesSystem : Singleton<BakeriesSystem>
{
    public BakeriesAsset bakeriesAsset; //asset przechowujacy gameObject piekarni
    public Transform bakeriesParent; //Transform pod ktorym (w hierarchi) są tworzone piekarnie na scenie

    List<Bakery> _bakeries = new List<Bakery>(); //lista wszystkich piekarn
        
    private int _numberOfWorkPlace = 2; //liczba miejsc pracy w każdej piekarni (w kazdej jest tyle samo miejsc)


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
	void Start()
	{
		AddBakery();
	}


    public void AddWorkPlace() //dodaje miejsce pracy do wszystkich piekarń
    {
        _numberOfWorkPlace++;
    }
    public void AddBakery() //tworzy nową piekranie
    {
		GameObject newBakery = Instantiate(bakeriesAsset.simpleBakery,bakeriesParent);
        _bakeries.Add(newBakery.GetComponent<Bakery>());
    }
    public bool RemoveBakery() //usuwa ostatnia piekarnie
    {
        if (_bakeries.Count > 1) //nie mozna usunac ostatniej piekarni
        {
            _bakeries.Last().DestroyBakery();
            _bakeries.Remove(_bakeries.Last());
            return true;
        }
        return false;
    }


    public void UpgradeBakery()
    {
        switch (_bakeryLevel)
        {
            case 0:             //upgrade na poziom 1 - dodaje mnoznik pkt
                _bakeryLevel++;
                foreach (Bakery element in _bakeries)
                {
                    element.GetComponent<AutoPointsModifier>().AddPointsMultipler(2f);
                }
                break;
            case 1:         //upgrade do poziomu 2 - zwieksza miejsca dla pracownikow o 1
                _bakeryLevel++;
                _numberOfWorkPlace++;
                break;
            case 2:         //upgrade do poziomu 3 - zwieksza punkty dodawane automatycznie o 5
                _bakeryLevel++;
                foreach (Bakery element in _bakeries)
                {
                    element.GetComponent<AutoPointsModifier>().AddAutoPoints(5);
                }
                break;
            case 3:         //upgrade do poziomu 4 - zwieksza ilosc miejsc o 1, zwieksza mnoznik
                _bakeryLevel++;
                _numberOfWorkPlace++;
                foreach (Bakery element in _bakeries)
                {
                    element.GetComponent<AutoPointsModifier>().AddPointsMultipler(2f);
                }
                break;


        }
    }

}
