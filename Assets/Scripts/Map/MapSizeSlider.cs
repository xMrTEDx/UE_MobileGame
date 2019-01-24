using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSizeSlider : MonoBehaviour {

	public CameraPositionController cameraPositionController;
	private Slider slider;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		slider = GetComponent<Slider>();
		slider.minValue = 1;
		slider.maxValue = 10;
		slider.value = cameraPositionController.cameraViewScaller;

		slider.onValueChanged.AddListener( v => {
			cameraPositionController.cameraViewScaller = v;
		});
	}
}
