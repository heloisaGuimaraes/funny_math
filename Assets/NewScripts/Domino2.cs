using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino2 : MonoBehaviour {

	public GameObject prefab;
	public static int gridX;
	public static int gridY;
	public int resT;

    public SoundPlayer soundPlayer;

	float spacingX, spacingY;
	int px, py,  resx, resy;
	int v1, v2, v3, v4, r, rr;
	public static int vzs;
	bool ch;

	float xx, yy;
	public static bool chG;

	void Start() {
		Domino1.chG = false;
		Dados.chG = false;
		ObjS.chG = false;

        soundPlayer = FindObjectOfType<SoundPlayer>();
		if (vzs == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l1sb;
			soundPlayer.audioSource.Play ();
		}

        chG = true;
		manda.fase = "Level1Sb";
		manda.pfase = "BlockSB";
		manda.nfase = "2 - SUBTRAÇÃO";
		manda.num = 2;
		v1 = Random.Range (1, 3);
		v2 = Random.Range (2, 6);
		if (v2 == 4) {
			v1 = 1;
			v2 = 1;

		}else if (v2 == 5) {
			v1 = 1;
			v2 = 5;
		}
		r = v1 * v2;

		v3 = Random.Range (1, 3);
		v4 = Random.Range (2, 6);
		if (v4 == 4) {
			v3 = 1;
			v4 = 1;

		}else if (v4 == 5) {
			v3 = 1;
			v4 = 5;

		}
		rr = v3 * v4;


		if (r > rr) {
			//print ("Op 1");

			inst1 (v1, v2);
			inst2 (v3, v4);

		} else {
			//print ("Op 2");
			inst1 (v3, v4);
			inst2 (v1, v2);

		}
		manda.res = manda.res1 - manda.res2;

		//print (manda.res);
	}




	public void inst1(int a, int b){
		
		if (b == 5) {
			gridX = 2;
			gridY = 2;
			ch = true;
		} else if (b == 4) {
			gridX = 1;
			gridY = 1;
			ch = false;

		} 

		else {
			gridX = a;
			gridY = b;
			ch = false;
		}

		xxx ();

		if (gridY == 1){
			py = 1;
			resy = gridY;
			gridY = 2;
			spacingY = 0.6f;
		}else if (gridY == 2){
			py = 0;
			resy = gridY;
			spacingY = 1f;

		}
		if (gridY == 3){
			py = 0;
			resy = gridY;
			spacingY = 0.65f;
		}
		resT = resx * resy;
		//print (resT);
		pX ();
		if (ch) {
			xx = -1.5f;
			yy = 0.5f;
			ex();
			resT += 1;
		}
		manda.res1 = resT;

	}

	//=============================================================//=============================================================//=============================================================
	public void inst2(int a, int b){
		

		if (b == 5) {
			gridX = 2;
			gridY = 2;
			ch = true;
		} else if (b == 4) {
			gridX = 1;
			gridY = 1;
			ch = false;

		} 

		else {
			gridX = a;
			gridY = b;
			ch = false;
		}

		xxx ();

		if (gridY == 1){
			py = -9;
			resy = gridY;
			gridY = -8;
			spacingY = 0.2f;
		}

		if (gridY == 2){
			py = -2;
			resy = gridY;
			gridY = 0;
			spacingY = 1.1f;
		}

		if (gridY == 3){
			py = -4;
			resy = gridY;
			gridY = -1;
			spacingY = 0.65f;
		}

		resT = resx * resy;
		//print (resT);
		pX ();
		if (ch) {
			xx = -1.5f;
			yy = -1.65f;
			ex();
			resT += 1;
		}
		manda.res2 = resT;

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
		//resT += 1;
		//print ("2: " + resT);
	}

	public void xxx(){ // valores para X
		if (gridX == 1) {
			spacingX = 0.5f;
			px = -3;
			resx = gridX;
			gridX = -2;
		}
		if (gridX == 2) {
			spacingX = 1f;
			px = -2;
			resx = gridX;
			gridX = 0;


		}
		if (gridX == 3) {

			spacingX = 0.7f;
			px = -3;
			resx = gridX;
			gridX = 0;
		}
	}


}
