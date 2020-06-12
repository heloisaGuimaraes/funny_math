using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class qObjetos : MonoBehaviour {
	public GameObject prefab;
	public static int gridX;
	public static int gridY;
	public static int resT;
	public static int vzs;

	public SoundPlayer soundPlayer;
	public GameObject ob1, ob2, ob3, ob4, ob5, pause;//necessarios para o menu de pausa

	float spacingX, spacingY;
	int px, py,  resx, resy, a, b;

	bool ch;
	bool chX, chY, chY1;
	float xx, yy;
	//======================================================
	public Text b1;
	public Text b2;
	public Text b3;
	public Text b4;
	public static bool erro;

	public static int res;

	void Start() {
		erro = false;
		if (vzs == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l2;
			soundPlayer.audioSource.Play ();
		}

        soundPlayer = FindObjectOfType<SoundPlayer>();
		manda.fase = "Level3";
		manda.pfase = "BlockCN";//"Level3";
		manda.nfase = "4 - CONHECENDO OS NÚMEROS.";
		manda.num = 4;


		a = Random.Range (1, 3);
		b = Random.Range (2, 6);

		if (b == 4) {
			gridX = 2;
			gridY = 2;
			ch = true;
		}else if (b == 5) {
			gridX = 1;
			gridY = 1;
			ch = false;

		} else {
			gridX = a;
			gridY = b;
			ch = false;
		}


		inst1 ();

		pos();
	}

	void Update () {
		
		if (erro){
			pos();
			erro = false;
		}

	}


	public void inst1(){
		if (gridX == 1) {
			spacingX = 1f;
			px = 0;
			resx = gridX;
			gridX = 1;
			prefab.transform.localScale = new Vector3 (1.5f, 1.5f, 1f);
		}//OK

		if (gridX == 2) {
			spacingX = 1f;
			px = -1;
			resx = gridX;
			gridX = 2;
			chX = true;


		}// OK


		if (gridX == 3) {
			spacingX = 1.3f;
			px = -1;
			resx = gridX;
			gridX = 2;
			chX = false;

		}// OK

		//=============================================================

		if (gridY == 1){
			py = 1;
			resy = gridY;
			gridY = 2;
			spacingY = 1.3f;
		}// OK

		else if (gridY == 2){
			py = 1;
			resy = gridY;
			gridY = 3;
			spacingY = 0.5f;
			chY = true;
			prefab.transform.localScale = new Vector3 (1.0f, 1.0f, 1f);

		} else if (gridY == 3){
			py = 1;
			resy = gridY;
			gridY = 4;
			spacingY = 0.4f;
			prefab.transform.localScale = new Vector3 (0.77f, 0.77f, 1f);
			chY1 = true;
			chY = false;
		}//OK
		//=============================================================
		resT = resx * resy;
		//print (resT);

		pX ();

		if (ch) {
			xx = 0;
			yy = 1.3f;
			ex();
		}
	}

	//=============================================================//=============================================================//=============================================================




	public void pX(){
		if (resT == 2 ) {
			px = -3;
			resx = gridX;
			gridX = -2;
			xx = px;
			spacingY = 0.85f;
			for (int y = py; y < gridY; y++) {
				for (int x = px; x < gridX; x++) {
					xx += 2f;
					yy = y * spacingY;
					Vector3 pos = new Vector3 (xx, yy, 0);
					Instantiate (prefab, pos, Quaternion.identity);
				}
			}
		} 

		else if (resT == 3) {
			px = -2;
			resx = gridX;
			gridX = -1;
			xx = -2f;


			spacingY = 0.65f;
			prefab.transform.localScale = new Vector3 (1, 1, 1f);
			for (int y = py; y < gridY; y++) {
				for (int x = px; x < gridX; x++) {
					xx += 1f;
					yy = y * spacingY;
					Vector3 pos = new Vector3 (xx, yy, 0);
					Instantiate (prefab, pos, Quaternion.identity);
				}
			}

		} else {
			for (int y = py; y < gridY; y++) {
				for (int x = px; x < gridX; x++) {
					if (x == 0 && chX ){
						
						x += 1;
				} if (y == 2 && chY ){
						spacingY = 1f;
					}
				if (y == 2 && chY1 ){
						
					spacingY = 0.62f;
				}
					if (y == 3 && chY1 ){
						
						spacingY = 0.72f;
					}
					xx = x * spacingX;
					yy = y * spacingY;

					Vector3 pos = new Vector3 (xx, yy, 0);
					Instantiate (prefab, pos, Quaternion.identity);
				}
			}

		}

	}

	public void ex(){
		//Vector3 pos = new Vector3 (xx, yy, 0);
		//Instantiate (prefab, pos, Quaternion.identity);
		prefab.transform.position = new Vector3 (xx, yy, 0);
		resT += 1;
		print (resT);
	}
	//================================================================================================================
	public void pos(){
		//res = t.resT;
		int x = Random.Range (1, 5);
		res = qObjetos.resT;
		switch (x) {
		case 1:
			b1.text = (res).ToString ();
			b2.text = (res + 1).ToString ();
			b3.text = (res + 2).ToString ();
			b4.text = (res - 1).ToString ();
			break;
		case 2:
			b1.text = (res + 1).ToString ();
			b2.text = (res).ToString ();
			b3.text = (res + 2).ToString ();
			b4.text = (res - 1).ToString ();
			break;
		case 3:
			b1.text = (res + 1).ToString ();
			b2.text = (res + 2).ToString ();
			b3.text = (res).ToString ();
			b4.text = (res - 1).ToString ();
			break;
		case 4:
			b1.text = (res + 1).ToString ();
			b2.text = (res + 2).ToString ();
			b3.text = (res - 1).ToString ();
			b4.text = (res).ToString ();
			break;
		}
	}


	public void pauseLevel(){
		//desativando os objetos
		ob1.SetActive (!(ob1).activeInHierarchy);
		ob2.SetActive (!(ob2).activeInHierarchy);
		ob3.SetActive (!(ob3).activeInHierarchy);
		ob4.SetActive (!(ob4).activeInHierarchy);
		ob5.SetActive (!(ob5).activeInHierarchy);
		pause.SetActive (!(pause).activeInHierarchy);

		if (!ob1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}

	}




}




