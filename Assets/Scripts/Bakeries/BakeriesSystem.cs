using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1e54SA8SEdzZv_b1uNvhh8DC1xmB66xVNYXVDytSeBYA/edit")]
public class BakeriesSystem : Singleton<BakeriesSystem>
{

    List<Bakery> _bakeries = new List<Bakery>(); //lista wszystkich piekarn
        
    private int _numberOfWorkPlace = 2; //liczba miejsc pracy w każdej piekarni (w kazdej jest tyle samo miejsc)

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
    public void AddBakery()
    {
		//TODO tworzy piekarnie na scenie i przyjmuje jego komponent Bakery
        _bakeries.Add(new Bakery());
    }
    public void RemoveBakery()
    {
        if (_bakeries.Count > 1) //nie mozna usunac ostatniej piekarni
            {
                Destroy(_bakeries.Last().gameObject);
                _bakeries.Remove(_bakeries.Last());
            }
    }

}
