using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollParticleSystemPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Camera.main.transform.position + new Vector3(0,Camera.main.orthographicSize+20,0);
	}
}
