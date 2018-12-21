﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Credit
{
    private float _interest = 0.2f;             // oprocentowanie
    private float _installment = 0;            // rata
    private float _moneyEarned = 0;            // kwota, jaką dostajemy, maks 100k
    private float _moneyToPay = 0;             // kwota do zapłaty
    private int _numberOfInstallments = 0;      //liczba rat

    public float interest
    {
        get
        {
            return _interest;
        }
    }
    public float installment
    {
        get
        {
            return _installment;
        }
    }
    public float moneyEarned
    {
        get
        {
            return _moneyEarned;
        }
    }
    public float moneyToPay
    {
        get
        {
            return _moneyToPay;
        }
    }
    public float numberOfInstallments
    {
        get
        {
            return _numberOfInstallments;
        }
    }

    public Credit(float moneyToGet, int installments)
    {
        _moneyEarned = moneyToGet;
        _numberOfInstallments = installments;

        for(int i = 1; i < _moneyEarned/10000; i++)
        {
            _interest -= 0.01f;
        }
        for (int i = 1; i < installments / 12; i++)
        {
            _installment += 0.01f;
        }

        _moneyToPay = _moneyEarned + _moneyEarned * _interest;
        _installment = _moneyToPay / _numberOfInstallments;
    }

    public void PayInstallment()
    {
        _numberOfInstallments -= 1;
    }
}

