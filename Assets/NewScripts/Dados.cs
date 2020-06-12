using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dados : MonoBehaviour {

	public GameObject prefab;
	public GameObject prefab2;
	public GameObject prefab3;
	public static int gridX;
	public static int gridY;
	public int resT;

    public SoundPlayer soundPlayer;

	float spacingX, spacingY;
	int px, py,  resx, resy, a, b;

	bool ch;

	float xx, yy;
	public static int vzs;
	public static bool chG;

	void Start() {
		if (vzs == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l2sm;
			soundPlayer.audioSource.Play ();
		}
        soundPlayer.audioSource.Play();


        chG = true;
		manda.fase = "Level2Sm";
		manda.pfase = "BlockSM";
		//manda.pfase = "Level3Sm";
		manda.nfase = "3 - SOMA";
		manda.num = 3;
		a = Random.Range (1, 3);
		b = Random.Range (2, 6);

		if (b == 4) {
			gridX = 2;
			gridY = 2;
			ch = true;
		} else if (b == 5) {
			gridX = 1;
			gridY = 1;
			ch = false;

		} else if (a == 1 && b == 2){
			gridX = a;
			gridY = b;
			ch = false;
		} else {
			gridX = a;
			gridY = b;
			ch = false;
		}


		inst1 ();
		manda.res1 = resT;
		manda.res = resT;
		a = Random.Range (1, 3);
		b = Random.Range (2, 6);

		if (b == 4) {
			gridX = 2;
			gridY = 2;
			ch = true;
		} else if (b == 5) {
			gridX = 1;
			gridY = 1;
			ch = false;

		} else if (a== 1 && b == 2){
			gridX = a;
			gridY = b;
			ch = false;
		} else {
			gridX = a;
			gridY = b;
			ch = false;
		}


		inst2 ();
		manda.res += resT;
		manda.res2 = resT;
		//print ("Soma" + manda.res);
	}




	public void inst1(){
		if (gridX == 1) {
			spacingX = 0.5f;
			px = -3;
			resx = gridX;
			gridX = -2;
		}//OK

		if (gridX == 2) {
			spacingX = 1f;
			px = -2;
			resx = gridX;
			gridX = 0;


		}// OK


		if (gridX == 3) {

			spacingX = 0.7f;
			px = -3;
			resx = gridX;
			gridX = 0;


		}// OK

		//=============================================================

		if (gridY == 1){
			py = 1;
			resy = gridY;
			gridY = 2;
			spacingY = 0.6f;
			prefab3.transform.position = new Vector3 (-1.48f, 0.6f, 0f);

		}// OK

		else if (gridY == 2){
			py = 0;
			resy = gridY;
			spacingY = 1f;
			prefab3.transform.position = new Vector3 (-1.48f, 0.53f, 0f);
		}// OK

		if (gridY == 3){
			py = 0;
			resy = gridY;
			spacingY = 0.65f;
			prefab3.transform.position = new Vector3 (-1.48f, 0.65f, 0f);
		}//OK
		//=============================================================
		resT = resx * resy;
		//print (resT);

		pX ();

		if (ch) {
			xx = -1.5f;
			yy = 0.5f;
			ex();
		}
	}

	//=============================================================//=============================================================//=============================================================
	public void inst2(){
		if (gridX == 1) {
			spacingX = 0.5f;
			px = -3;
			resx = gridX;
			gridX = -2;
		}//OK

		if (gridX == 2) {
			spacingX = 1f;
			px = -2;
			resx = gridX;
			gridX = 0;


		}// OK


		if (gridX == 3) {
			//prefab.transform.localScale = new Vector3 (0.6f, 0.6f, 0);
			spacingX = 0.7f;
			px = -3;
			resx = gridX;
			gridX = 0;


		}// OK

		//=============================================================

		if (gridY == 1){
			py = -9;
			resy = gridY;
			gridY = -8;
			spacingY = 0.2f;
			prefab2.transform.position = new Vector3 (-1.48f, -1.8f, 0f);
		}// OK

		if (gridY == 2){
			py = -2;
			resy = gridY;
			gridY = 0;
			spacingY = 1.25f;
			prefab2.transform.position = new Vector3 (-1.48f, -1.85f, 0f);
		}// OK

		if (gridY == 3){
			py = -4;
			resy = gridY;
			gridY = -1;
			spacingY = 0.65f;
			prefab2.transform.position = new Vector3 (-1.48f, -1.95f, 0);
		}//OK

		//=============================================================
		resT = resx * resy;
		//print (resT);

		pX ();

		if (ch) {
			xx = -1.5f;
			yy = -1.87f;
			ex();
		}
	}



	public void pX(){
		if (resT == 2 ) {
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
		print (prefab2.transform.position);
	}


}
