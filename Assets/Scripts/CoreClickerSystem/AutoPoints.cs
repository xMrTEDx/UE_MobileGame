using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1ejpS-XV8fF2pCr_84tdIhLtNwRt5clxlDjzXzu49Xis/edit")]
public class AutoPoints : MonoBehaviour
{
    //przechowuje sume wszystkich punktow dodawanych co kazdy cykl zegara

    //pola
    private float _liczbaPunktowWPuli = 0;
    public float LiczbaPunktowWPuli
    {
        get { return _liczbaPunktowWPuli; }
    }

    private float _mnoznikPunktowWPuli = 1;
    public float MnoznikPunktowWPuli
    {
        get { return _mnoznikPunktowWPuli; }
    }

    //metody
    public void DodajLiczbePunktow(float liczbaDodana)
    {
        _liczbaPunktowWPuli += liczbaDodana;
    }
    public void DodajLiczbePunktow(float liczbaDodana, int czasTrwaniaSekund)
    {
        StartCoroutine(AddPointsTemporarily(liczbaDodana, czasTrwaniaSekund));
    }

    public void DodajMnoznikPunktow(float mnoznik)
    {
        _mnoznikPunktowWPuli *= mnoznik;
    }
    public void DodajMnoznikPunktow(float mnoznik, int czasTrwaniaSekund)
    {
        StartCoroutine(AddMultiplerTemporarily(mnoznik, czasTrwaniaSekund));
    }

    // metody nie uzywane z uwagi na to iz z tego skryptu korzysta "AutoPointsModifier" ktory reprezentuje kazdy obiekt w grze ktory przynosi punkty automatyczne
    // i kazdy taki obiekt przechowuję swoją liczbę punktów jaką przynosi, więc przy zmianie jago punktów sam wylicza różnice z nowej i poprzedniej wartości
    
    // public void ZmienLiczbePunktow(int liczbaNowa, int liczbaPoprzednia)
    // {
    //     DodajLiczbePunktow(liczbaNowa - liczbaPoprzednia);
    // }
    // public void ZmienLiczbePunktow(int liczbaNowa, int liczbaPoprzednia, int czasTrwaniaSekund)
    // {
    //     DodajLiczbePunktow(liczbaNowa - liczbaPoprzednia, czasTrwaniaSekund);
    // }


    // public void ZmienMnoznikPunktow(float mnoznikNowy, float mnoznikPoprzedni)
    // {
    //     DodajMnoznikPunktow(mnoznikNowy / mnoznikPoprzedni);
    // }
    // public void ZmienMnoznikPunktow(float mnoznikNowy, float mnoznikPoprzedni, int czasTrwaniaSekund)
    // {
    //     DodajMnoznikPunktow(mnoznikNowy / mnoznikPoprzedni, czasTrwaniaSekund);
    // }


    private IEnumerator AddPointsTemporarily(float liczbaDodana, int czasTrwaniaSekund)
    {
        DodajLiczbePunktow(liczbaDodana);
        yield return new WaitForSeconds(czasTrwaniaSekund);
        DodajLiczbePunktow(-liczbaDodana);
    }
    private IEnumerator AddMultiplerTemporarily(float mnoznik, int czasTrwaniaSekund)
    {
        DodajMnoznikPunktow(mnoznik);
        yield return new WaitForSeconds(czasTrwaniaSekund);
        DodajMnoznikPunktow(-mnoznik);
    }
    public void ResetValues()
    {
        _liczbaPunktowWPuli = 0;
        _mnoznikPunktowWPuli = 1;
    }
}