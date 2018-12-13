using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditWindow : Singleton<CreditWindow>
{

    public Slider sliderPozyczka;
    public Slider sliderRaty;
    public Button wezPozyczke;
    public void Init()
    {
		sliderRaty.value = 0;
		sliderRaty.value = 0;
    }
    public void WezPozyczke()
    {
        //TODO wez pozyczke
        Debug.Log(string.Format("Pozyczka, wartosc: {0} \t liczba rat: {1}", sliderPozyczka.value, sliderRaty.value));

        CloseWindow();
    }
    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}
