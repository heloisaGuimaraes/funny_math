using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opcoes : MonoBehaviour {
	//codigo para os botoes do nivel 2

	public Text b1;
	public Text b2;
	public Text b3;
	public Text b4;

	int but;
	public static int res;
	public Text txt;

	// Use this for initialization
	void Start () {
		but = Random.Range (1, 5);


	}
	
	// Update is called once per frame
	void Update () {
		pos(but);
		op ();

	}

	public void pos(int x){
		//res = t.resT;
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
	public void op(){
		if (manda.c == 0 || manda.c == 6 || manda.c == 8 || manda.c == 9 || manda.c == 17 || manda.c == 19 || manda.c == 20 || manda.c == 22 || manda.c == 24 || manda.c == 25 || manda.c == 26 || manda.c == 27 || manda.c == 28) {
			txt.text = "Quantos      tem o quadro abaixo?";
		} else {
			txt.text = "Quantas      tem o quadro abaixo?";
		}
	
	}
}
