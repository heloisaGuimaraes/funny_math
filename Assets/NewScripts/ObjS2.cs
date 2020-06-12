using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjS2 : MonoBehaviour {
	public GameObject prefab;
	public GameObject prefab1;
	public GameObject prefab2;
	public static int gridX;
	public static int gridY;
	public int resT;

    public SoundPlayer soundPlayer;

	public Text txt;

	float spacingX, spacingY;
	int px, py,  resx, resy;

	public static int vzs;
	int v1, v2, v3, v4, r, rr;
	float xx, yy;
	public static bool chG;

	void Start() {
		Domino1.chG = false;
		Dados.chG = false;
		ObjS.chG = false;

        soundPlayer = FindObjectOfType<SoundPlayer>();
		if (vzs == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l3sb;
			soundPlayer.audioSource.Play ();
		}


        chG = true;
		manda.fase = "Level3Sb";
		manda.pfase = "BlockSB";
		manda.nfase = "4 - SUBTRAÇÃO.";
		manda.num = 4;
		op ();

		v1 = Random.Range (1, 4);
		v2 = Random.Range (2, 5);
		if (v2 == 4) {
			v1 = 1;
			v2 = 1;
		}
		r = v1 * v2;

		v3 = Random.Range (1, 4);
		v4 = Random.Range (2, 5);
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
		//print ("ResT: " + manda.res);
	
	}


	public void inst1(int a, int b){
		if (b == 4) {
			gridX = 1;
			gridY = 1;
			//ch = false;

		}else {
			gridX = a;
			gridY = b;
			//ch = false;
		}
		xxx ();
		if (gridY == 1){
			py = 1;
			resy = gridY;
			gridY = 2;
			spacingY = 0.6f;

		}

		else if (gridY == 2){
			py = 0;
			resy = gridY;
			spacingY = 1f;
		}

		if (gridY == 3){
			py = 0;
			resy = gridY;
			spacingY = 0.65f;
			prefab.transform.localScale = new Vector3 (0.55f, 0.55f, 1);
			prefab2.transform.position = new Vector3 (-1.4f, 0.6f, 0.0f);
		}
		//=============================================================
		resT = resx * resy;
		//print (resT);

		pX ();
		manda.res1 = resT;

	}


	public void inst2(int a, int b){
		if (b == 4) {
			gridX = 1;
			gridY = 1;
			//ch = false;

		}else {
			gridX = a;
			gridY = b;
			//ch = false;
		}
		xxx ();

		if (gridY == 1){
			py = -2;
			resy = gridY;
			gridY = -1;
			spacingY = 1f;

		}

		if (gridY == 2){
			py = -3;
			resy = gridY;
			gridY = -1;
			spacingY = 1f;
			prefab1.transform.position = new Vector3 (-1.4f, -2.5f, 0);

		}

		if (gridY == 3){
			py = -4;
			resy = gridY;
			gridY = -1;
			spacingY = 0.65f;
			prefab.transform.localScale = new Vector3 (0.55f, 0.55f, 1);
		}

		//=============================================================
		resT = resx * resy;
		//print (resT);

		pX ();
		manda.res2 = resT;
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


	public void xxx(){
		if (gridX == 1) {
			spacingX = 0.7f;
			px = -2;
			resx = gridX;
			gridX = -1;
			prefab.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (gridX == 2) {
			spacingX = 0.93f;
			px = -2;
			resx = gridX;
			gridX = 0;

			prefab.transform.localScale = new Vector3 (0.78f, 0.78f, 1);
		}
		if (gridX == 3) {
			spacingX = 0.7f;
			px = -3;
			resx = gridX;
			gridX = 0;

			prefab.transform.localScale = new Vector3 (0.65f, 0.65f, 1);
		}

	}

	public void op(){
		if (manda.c == 0 || manda.c == 6 || manda.c == 8 || manda.c == 9 || manda.c == 17 || manda.c == 19 || manda.c == 20 || manda.c == 22 || manda.c == 24 || manda.c == 25 || manda.c == 26 || manda.c == 27 || manda.c == 28) {
			txt.text = "DIGA QUANTOS          HÁ EM CADA CONJUNTO, E SUBTRAIA AS QUANTIDADES.";
		} else {
			txt.text = "DIGA QUANTAS          HÁ EM CADA CONJUNTO, E SUBTRAIA AS QUANTIDADES.";
		}


	}


}
