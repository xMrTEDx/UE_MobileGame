using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPositionController : MonoBehaviour {

	// Update is called once per frame
	[Range(1,10)]
	public float cameraViewScaller = 3f;
	void Update () {
		Camera.main.transform.position = transform.position;
		Camera.main.GetComponent<Camera>().orthographicSize = Screen.currentResolution.height*Screen.currentResolution.height/(1000*cameraViewScaller);
	}
}
