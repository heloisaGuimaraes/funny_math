using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t : MonoBehaviour {

	// script para os objetos menores da pasta obj2
	public GameObject prefab;
	public static int gridX;
	public static int gridY;
	public static int resT;
	public float spacing = 0.5f;
	int px, py,  resx, resy, a, b;



	void Start() {

		//
		a = Random.Range (1, 5);
		b = Random.Range (1, 5);
		//=============================================================

		if (a > b) {
			gridX = a;
			gridY = b;
		} else {
			gridX = b;
			gridY = a;
		}

		if (gridY == 2 ){
			gridY += 1;
			//print ("Deu 2");
		}
		//=============================================================
		 // pensar no 2,4, 6,
		if ((gridX == 1) ) {
			prefab.transform.localScale = new Vector3 (1f, 1f, 0);

			spacing = 1f;
			px = 0;
			py = 0;
			resx = gridX;

		}//OK
		if (((gridX + 1) == 3) ) {
			prefab.transform.localScale = new Vector3 (1f, 1f, 0);
			spacing = 1f;
			px = -1;

			resx = (gridX + 1);

		}//OK

		if (((gridX + 2) == 5)) {
			prefab.transform.localScale = new Vector3 (0.8f, 0.8f, 0);
			spacing = 1f;
			px = -2;

			resx = gridX + 2;

		} // OK

		if (((gridX + 3) == 7) ) {
			prefab.transform.localScale = new Vector3 (0.6f, 0.6f, 0);
			spacing = 0.7f;
			px = -3;
			resx = (gridX + 3);
		} // OK

		//=============================================================

		if (gridY == 1){
			py = 1;
			gridY = 2;
			resy = gridY -1;

		}

		if (gridY == 3){
			py = 0;
			resy = gridY;
		}
		if (gridY == 4){
			py = 0;
			resy = gridY;
		}
		//=============================================================
		resT = (resx * resy);
		print (resx);
		print (resy);
		print (resT);
		//=============================================================
		for ( int y = py; y < gridY; y++) {
			for (int x = px; x < gridX; x++) {
				Vector3 pos = new Vector3(x, y, 0) * spacing;
				Instantiate(prefab, pos, Quaternion.identity);
			}
		}

	}
	void Update () {

	}
}
