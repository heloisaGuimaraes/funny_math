using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redmensionar : MonoBehaviour {
	float a;
	//float b;
	float screenW, screenH;
	// Use this for initialization
	void Start () {
		a = transform.localScale.x;
		//b = transform.localScale.y;

	}

	// Update is called once per frame
	void Update () {
		screenW = Screen.width;
		screenH = Screen.height;

		transform.localScale = new Vector3 ((a*screenW/screenH), transform.localScale.y, transform.localScale.z);


	}
}
