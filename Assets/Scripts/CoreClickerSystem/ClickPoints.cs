using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPoints : MonoBehaviour
    {
        // pola
        private int _liczbaPunktowPrzyKliknieciu = 1;
        public int LiczbaPunktowPrzyKliknieciu
        {
            get { return _liczbaPunktowPrzyKliknieciu; }
        }
        private float _mnoznikPunktowPrzyKliknieciu = 1;
        public float MnoznikPunktowPrzyKliknieciu
        {
            get { return _mnoznikPunktowPrzyKliknieciu; }
        }

        //metody
        public void ZwiekszLiczbePunktow(int liczbaDodana)
        {
            _liczbaPunktowPrzyKliknieciu += liczbaDodana;
        }
        public void ZwiekszLiczbePunktow(int liczbaDodana, int czasTrwaniaSekund)
        {
            StartCoroutine(AddPointsTemporarily(liczbaDodana, czasTrwaniaSekund));
        }

        public void DodajMnoznikPunktow(float mnoznik)
        {
            _mnoznikPunktowPrzyKliknieciu *= mnoznik;
        }
        public void DodajMnoznikPunktow(float mnoznik, int czasTrwaniaSekund)
        {
            StartCoroutine(AddMultiplerTemporarily(mnoznik, czasTrwaniaSekund));
        }

        private IEnumerator AddPointsTemporarily(int liczbaDodana, int czasTrwaniaSekund)
        {
            ZwiekszLiczbePunktow(liczbaDodana);
            yield return new WaitForSeconds(czasTrwaniaSekund);
            ZwiekszLiczbePunktow(-liczbaDodana);
        }
        private IEnumerator AddMultiplerTemporarily(float mnoznik, int czasTrwaniaSekund)
        {
            DodajMnoznikPunktow(mnoznik);
            yield return new WaitForSeconds(czasTrwaniaSekund);
            DodajMnoznikPunktow(-mnoznik);
        }

    }
