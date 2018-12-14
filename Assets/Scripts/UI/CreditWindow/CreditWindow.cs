using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditWindow : Singleton<CreditWindow>
{

    public Slider sliderLoan;
    public Slider sliderInstallments;
    public Button getLoan;
    public Button back;
    public void ShowCreditWindow()
    {
        ClickerGame.Instance.PauseGame();

        sliderInstallments.minValue = 6;
        sliderInstallments.maxValue = 60;
        sliderInstallments.value = 6;
        sliderLoan.value = 10000;
        sliderLoan.minValue = 10000;
        sliderLoan.maxValue = 100000;
    }
    public void GetLoan()
    {
        if (ClickerGame.Instance.ChargesSystem.TakeCredit((int)sliderLoan.value, (int)sliderInstallments.value))
        {
            Debug.Log(string.Format("Wzieta pozyczka, wartosc: {0} \t liczba rat: {1}", sliderLoan.value, sliderInstallments.value));
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
