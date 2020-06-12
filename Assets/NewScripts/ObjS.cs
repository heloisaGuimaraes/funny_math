using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjS : MonoBehaviour {

	public GameObject prefab;
	public GameObject prefab1;
	public GameObject prefab2;
	public static int gridX;
	public static int gridY;
	public int resT;

	public Text txt;

	float spacingX, spacingY;
	int px, py,  resx, resy, a, b;

	public static int vzs;

	float xx, yy;
	public static bool chG;

    public SoundPlayer soundPlayer;

	void Start() {
        
		chG = true;
		manda.fase = "Level3Sm";
		manda.pfase = "BlockSM";
		manda.nfase = "4 - SOMA";
		manda.num = 4;
		if (vzs == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l3sm;
			soundPlayer.audioSource.Play ();
		}
		op ();
		a = Random.Range (1, 4);
		b = Random.Range (2, 5);
		//print ("a: " + a + "b: " + b);
		if (b == 4) {//4
			gridX = 1;
			gridY = 1;

		} else {
			gridX = a;
			gridY = b;

		}


		inst1 ();
		manda.res1 = resT;
		manda.res = resT;


		a = Random.Range (1, 4);
		b = Random.Range (2, 5);
		//print ("a: " + a + "b: " + b);
		if (b == 4) {
			gridX = 1;
			gridY = 1;

		} else {
			gridX = a;
			gridY = b;

		}


		inst2 ();
		manda.res += resT;
		manda.res2 = resT;
		print ("Soma" + manda.res);

	}




	public void inst1(){
		if (gridX == 1) {
			spacingX = 0.7f;
			px = -2;
			resx = gridX;
			gridX = -1;
			prefab.transform.localScale = new Vector3 (1, 1, 1);
		}//OK

		if (gridX == 2) {
			spacingX = 0.93f;
			px = -2;
			resx = gridX;
			gridX = 0;

			prefab.transform.localScale = new Vector3 (0.78f, 0.78f, 1);
		}// OK


		if (gridX == 3) {

			spacingX = 0.7f;
			px = -3;
			resx = gridX;
			gridX = 0;

			prefab.transform.localScale = new Vector3 (0.65f, 0.65f, 1);

		}// OK

		//=============================================================

		if (gridY == 1){
			py = 1;
			resy = gridY;
			gridY = 2;
			spacingY = 0.6f;

		}// OK

		else if (gridY == 2){
			py = 0;
			resy = gridY;
			spacingY = 1f;
		}// OK

		if (gridY == 3){
			py = 0;
			resy = gridY;
			spacingY = 0.65f;
			prefab.transform.localScale = new Vector3 (0.55f, 0.55f, 1);
			prefab2.transform.position = new Vector3 (-1.4f, 0.6f, 0.0f);
		}//OK
		//=============================================================
		resT = resx * resy;
		//print (resT);

		pX ();

	}

	//=============================================================//=============================================================//=============================================================
	public void inst2(){
		if (gridX == 1) {
			spacingX = 0.7f;
			px = -2;
			resx = gridX;
			gridX = -1;
			prefab.transform.localScale = new Vector3 (1, 1, 1);
		}//OK

		if (gridX == 2) {
			spacingX = 0.93f;
			px = -2;
			resx = gridX;
			gridX = 0;

			prefab.transform.localScale = new Vector3 (0.78f, 0.78f, 1);
		}// OK


		if (gridX == 3) {

			spacingX = 0.7f;
			px = -3;
			resx = gridX;
			gridX = 0;

			prefab.transform.localScale = new Vector3 (0.65f, 0.65f, 1);

		}// OK

		//=============================================================

		if (gridY == 1){
			py = -2;
			resy = gridY;
			gridY = -1;
			spacingY = 1f;

		}// OK

		if (gridY == 2){
			py = -3;
			resy = gridY;
			gridY = -1;
			spacingY = 1f;
			prefab1.transform.position = new Vector3 (-1.4f, -2.5f, 0);

		}// OK

		if (gridY == 3){
			py = -4;
			resy = gridY;
			gridY = -1;
			spacingY = 0.65f;
			prefab.transform.localScale = new Vector3 (0.55f, 0.55f, 1);
		}//OK

		//=============================================================
		resT = resx * resy;
		//print (resT);

		pX ();

	}



	public void pX(){
		if (resT == 2 ) {
			prefab.transform.localScale = new Vector3 (0.9f, 0.9f, 1);
			px = -3;
			resx = gridX;
			gridX = -2;
			xx = px;
			for (int y = py; y < gridY; y++) {
				for (int x = px; x < gridX; x++) {
					xx += 1;
					yy = y * spacingY;
					Vector3 pos = new Vector3 (xx, yy, 0);
					Instantiate (prefab, pos, Quaternion.identity);
				}
			}
		} 

		else if (resT == 3) {
			prefab.transform.localScale = new Vector3 (0.7f, 0.7f, 1);
			px = -3;
			resx = gridX;
			gridX = -2;
			xx = -2.5f;
			for (int y = py; y < gridY; y++) {
				for (int x = px; x < gridX; x++) {
					xx += 0.5f;
					yy = y * spacingY;
					Vector3 pos = new Vector3 (xx, yy, 0);
					Instantiate (prefab, pos, Quaternion.identity);
				}
			}

		} 

		else {
			for (int y = py; y < gridY; y++) {
				for (int x = px; x < gridX; x++) {
					xx = x * spacingX;
					yy = y * spacingY;
					Vector3 pos = new Vector3 (xx, yy, 0);
					Instantiate (prefab, pos, Quaternion.identity);
				}
			}

		}

	}

	public void ex(){
		Vector3 pos = new Vector3 (xx, yy, 0);
		Instantiate (prefab, pos, Quaternion.identity);
		resT += 1;
		//print ("2: " + resT);
	}

	public void p(){
		print (prefab1.transform.position);
	}

	public void op(){
		if (manda.c == 0 || manda.c == 6 || manda.c == 8 || manda.c == 9 || manda.c == 17 || manda.c == 19 || manda.c == 20 || manda.c == 22 || manda.c == 24 || manda.c == 25 || manda.c == 26 || manda.c == 27 || manda.c == 28) {
			txt.text = "DIGA QUANTOS          HÁ EM CADA CONJUNTO, E SOME AS QUANTIDADES.";
		} else {
			txt.text = "DIGA QUANTAS          HÁ EM CADA CONJUNTO, E SOME AS QUANTIDADES.";
		}


	}


}
