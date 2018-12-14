using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditWindow : Singleton<CreditWindow>
{

    public Slider sliderPozyczka;
    public Slider sliderRaty;
    public Button wezPozyczke;
    public Button powrot;
    public void ShowCreditWindow()
    {
        ClickerGame.Instance.PauseGame();

        sliderRaty.minValue = 6;
        sliderRaty.maxValue = 60;
        sliderRaty.value = 6;
        sliderPozyczka.value = 60000;
        sliderPozyczka.minValue = 10000;
        sliderPozyczka.maxValue = 100000;
    }
    public void WezPozyczke()
    {
        if (ClickerGame.Instance.ChargesSystem.TakeCredit((int)sliderPozyczka.value, (int)sliderRaty.value))
        {
            Debug.Log(string.Format("Wzieta pozyczka, wartosc: {0} \t liczba rat: {1}", sliderPozyczka.value, sliderRaty.value));
            CloseWindow();
        }
        else
        {
            //wyswietl uzytkownikowi ze nie moze wziasc kredytu
        }
    }
    public void CloseWindow()
    {
        ClickerGame.Instance.ResumeGame();
        Destroy(gameObject);
    }
}
