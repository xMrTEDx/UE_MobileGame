using System.Collections;
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
        if(slider.maxValue == 100)
        {
            text.text = (slider.value * 1000).ToString();
        }
        else
        {
            text.text = slider.value.ToString();
        }
        Debug.Log("Jakie słowa");
	}
}
