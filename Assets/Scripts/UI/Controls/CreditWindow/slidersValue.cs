﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidersValue : MonoBehaviour {

	Text text;
	public Slider slider;
	void Start () {
		text = GetComponent<Text>();
        AktualizujWartosc();
    }
    public void AktualizujWartosc()
	{
		text.text = slider.value.ToString();
        Debug.Log("Jakie słowa");
	}
}
