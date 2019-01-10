using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;

public class DataSystem : MonoBehaviour
{
    private static DateTime currentDate;

    public void Init() //uzywac zamiast start
    {
        currentDate = new DateTime(ClickerGame.Instance.GameSettings.dataSettings.year, ClickerGame.Instance.GameSettings.dataSettings.month, ClickerGame.Instance.GameSettings.dataSettings.day);
        WriteDate();
    }

    public void ChangeDay()
    {
        currentDate = currentDate.AddDays(1);
        WriteDate();
    }

    public void WriteDate()
    {
        StringBuilder date = new StringBuilder();
        date.Append(currentDate.Day);
        date.Append("-");
        if (currentDate.Month < 10)
        {
            date.Append(0);
        }
        date.Append(currentDate.Month);
        date.Append("-");
        date.Append(currentDate.Year);

        ClickerGame.Instance.MainCanvasClicker.dataText.text = date.ToString();
    }

    public DateTime GetCurrentDate()
    {
        return currentDate;
    }
}
