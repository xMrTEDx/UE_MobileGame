using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPoints : MonoBehaviour
    {
        //pola
        private int _liczbaPunktowWPuli = 0;
        public int LiczbaPunktowWPuli
        {
            get { return _liczbaPunktowWPuli; }
        }

        private float _mnoznikPunktowWPuli = 1;
        public float MnoznikPunktowWPuli
        {
            get { return _mnoznikPunktowWPuli; }
        }

        //metody
        public void DodajLiczbePunktow(int liczbaDodana)
        {
            _liczbaPunktowWPuli += liczbaDodana;
        }
        public void DodajLiczbePunktow(int liczbaDodana, int czasTrwaniaSekund)
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



        public void ZmienLiczbePunktow(int liczbaNowa, int liczbaPoprzednia)
        {
            DodajLiczbePunktow(liczbaNowa - liczbaPoprzednia);
        }
        public void ZmienLiczbePunktow(int liczbaNowa, int liczbaPoprzednia, int czasTrwaniaSekund)
        {
            DodajLiczbePunktow(liczbaNowa - liczbaPoprzednia, czasTrwaniaSekund);
        }


        public void ZmienMnoznikPunktow(float mnoznikNowy, float mnoznikPoprzedni)
        {
            DodajMnoznikPunktow(mnoznikNowy - mnoznikPoprzedni);
        }
        public void ZmienMnoznikPunktow(float mnoznikNowy, float mnoznikPoprzedni, int czasTrwaniaSekund)
        {
            DodajMnoznikPunktow(mnoznikNowy - mnoznikPoprzedni, czasTrwaniaSekund);
        }


        private IEnumerator AddPointsTemporarily(int liczbaDodana, int czasTrwaniaSekund)
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
    }