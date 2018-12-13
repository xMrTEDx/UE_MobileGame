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
    public void ShowCreditWindow(bool mozliwoscWyjscia)
    {
        ClickerGame.Instance.PauseGame();

        sliderRaty.value = 0;
        sliderRaty.value = 0;

        if (!mozliwoscWyjscia)
            Destroy(powrot.gameObject);
    }
    public void WezPozyczke()
    {
        if (sliderRaty.value != 0 && sliderRaty.value != 0)
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
        else
        {
            Debug.Log("Podano zle wartosci");
            //powiedz o tym uzytkownikowi
        }



    }
    public void CloseWindow()
    {
        ClickerGame.Instance.ResumeGame();
        Destroy(gameObject);
    }
}
