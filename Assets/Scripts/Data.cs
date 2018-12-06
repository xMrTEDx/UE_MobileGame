using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Data : Singleton<Data>
{ 
    private static DateTime startDate = new DateTime(2012, 04, 10);
    private static DateTime currentDate;

    void Start()
    {
        currentDate = startDate;
    }

    public void ChangeDay()
    {
        currentDate = currentDate.AddDays(1);
    }

    public string WritetDate()
    {
        StringBuilder date = new StringBuilder();
        date.Append(currentDate.Day);
        date.Append("-");
        if(currentDate.Month < 10)
        {
            date.Append(0);
        }
        date.Append(currentDate.Month);
        date.Append("-");
        date.Append(currentDate.Year);
        return date.ToString();
    }

    public DateTime GetCurrentDate()
    {
        return currentDate;
    }

    public DateTime GetStartDate()
    {
        return startDate;
    }
    
}
