using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaiorMenor : MonoBehaviour {

	public GameObject prefab;
	public static int gridX;
	public static int gridY;
	public static int resT1;
	public static int resT2;
	public float spacing = 0.5f;
	int px, py,  resx, resy, a, b;

	public static int qtd;
	// Use this for initialization
	public SoundPlayer soundPlayer;
	public GameObject ob1, ob2, ob3, ob4, pause;//necessarios para o menu de pausa

	void Start () {
		if (qtd == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l4;
			soundPlayer.audioSource.Play ();
		}

		manda.fase = "Level5";
		manda.pfase = "BlockCN";
		manda.nfase = "6 - CONHECENDO OS NÚMEROS.";
		soundPlayer = FindObjectOfType<SoundPlayer>();
		lado1 ();
		lado2 ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void lado1(){
	

		a = Random.Range (1, 4);// Ate 3
		b = Random.Range (1, 4);// Ate 3
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

		if ((gridX == 1) ) {// 1
			prefab.transform.localScale = new Vector3 (2f, 2f, 0);
			spacing = 1f;
			px = -5;//0;
			resx = gridX;
			gridX = (gridX - 5);


		}//OK
		if (((gridX + 1) == 3) ) {//2
			prefab.transform.localScale = new Vector3 (1f, 1f, 0);
			spacing = 1f;
			px = -6;
			resx = (gridX + 1);
			gridX = -(gridX + 1);

		}//OK

		if (((gridX + 2) == 5)) {//3
			prefab.transform.localScale = new Vector3 (0.8f, 0.8f, 0);
			spacing = 1f;
			px = -7;//-2;
			resx = gridX + 2;
			gridX = -(gridX-1);

		} // OK



		//=============================================================

		if (gridY == 1){
			py = 1;
			resy = gridY;
			gridY = 2; 


		}

		if (gridY == 3){
			py = 0;
			resy = gridY;

		}


		//=============================================================
		resT1 = (resx * resy);

		print ("1: " + resT1);
		//=============================================================
		gerar();
	}
	public void lado2(){
		a = Random.Range (1, 4);
		b = Random.Range (1, 4);
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
		if ((gridX == 1)) {
			prefab.transform.localScale = new Vector3 (2f, 2f, 0);
			spacing = 1f;
			px = 5;
			resx = gridX;
			gridX = (gridX + 5);


		}//OK

		if (((gridX + 1) == 3) ) {//2
			prefab.transform.localScale = new Vector3 (1f, 1f, 0);
			spacing = 1f;
			px = 4;//-1;
			resx = (gridX + 1);
			gridX = gridX + 5;

		}//OK

		if (((gridX + 2) == 5)) {//3
			prefab.transform.localScale = new Vector3 (0.8f, 0.8f, 0);
			spacing = 1f;
			px = 3;//-2;
			resx = gridX + 2;
			gridX = (gridX+5);

		} // OK


		//=============================================================

		if (gridY == 1){
			py = 1;
			resy = gridY;
			gridY = 2; // OLHAR


		}

		if (gridY == 3){
			py = 0;
			resy = gridY;

		}


		//=============================================================
		resT2 = (resx * resy);
		print ("2: " + resT2);
		//=============================================================
		gerar();
	}

	void gerar (){
		for ( int y = py; y < gridY; y++) {
			for (int x = px; x < gridX; x++) {
				Vector3 pos = new Vector3(x, y, 0) * spacing;
				Instantiate(prefab, pos, Quaternion.identity);
			}
		}
	}

	public void pauseLevel(){
		//desativando os objetos
		ob1.SetActive (!(ob1).activeInHierarchy);
		ob2.SetActive (!(ob2).activeInHierarchy);
		ob3.SetActive (!(ob3).activeInHierarchy);
		ob4.SetActive (!(ob4).activeInHierarchy);
		pause.SetActive (!(pause).activeInHierarchy);
		if (!ob1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}

	}
}
