using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadroObjetos3 : MonoBehaviour {

	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab4;

	GameObject prefabP, fil;

	public sorteioAtlas ob1;
	public sorteioAtlas ob2;
	public sorteioAtlas ob3;
	public sorteioAtlas ob4;


	public Text questao;

	public Text b1;
	public Text b2;
	public Text b3;
	public Text b4;

	public static int qtd;
	float px, py;
	int o1, o2, o3, o4, a;

	ArrayList obj = new ArrayList ();
	public static int m, oPai;

	public static bool aut = false, erro;
	public SoundPlayer soundPlayer;
	public GameObject obj1, obj2, obj3, obj4, obj5, pause;//necessarios para o menu de pausa

	void Start() {
		erro = false;
		manda.fase = "Level6_2";
		manda.pfase = "Level6_3";
		manda.nfase = "6 - CONHECENDO OS NÚMEROS.";
		manda.num = 6;
		soundPlayer = FindObjectOfType<SoundPlayer>();
		if (qtd == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l5;
			soundPlayer.audioSource.Play ();
		}

		sort1 ();

		for ( int y = 0; y < 3; y++) {
			for (int x = -2; x < 3; x++) {
				a = Random.Range (1, 5);
				if (a == 1) {
					o1 += 1;
					prefabP = prefab1;

				}
				else if (a == 2) {
					o2 += 1;
					prefabP = prefab2;

				}
				else if (a == 3) {
					o3 += 1;
					prefabP = prefab3;
				}
				else if (a == 4) {
					o4 += 1;
					prefabP = prefab4;

				}


				if (x == -2) {
					px = (x - (0.2f));

				} 

				if (x == -1) {
					px = (x - (0.09f));

				} 
				if (x == 0){
					px = x;
					//py = (y + (0.1f));
				} 

				if (x == 1){
					px = ((x) + (0.15f));

				}
				if (x == 2){
					px = ((x) + (0.25f));

				}

				if (y == 3) {
					py = y + 0.1f;
				} else {
					py = y;
				}
					
				Vector3 pos = new Vector3 (px, y, 0);
				Instantiate(prefabP, pos, Quaternion.identity);
			}
		}
		m = 0;
		opBut (m);

	}



	// ===========================================================
	public void sort1 () {//para escolher os sprites
		int vzs = 0;
		int n;
		while (true) {

			n = Random.Range (0, 28);
			if (!obj.Contains (n)) {
				//print (n);
				obj.Add (n);
				vzs += 1;
			}

			if (vzs == 4) {
				break;
			}
		}

		ob1.pos = ((int)obj [0]);
		ob2.pos = ((int)obj [1]);
		ob3.pos = ((int)obj [2]);
		ob4.pos = ((int)obj [3]);


	}
	// ==========================================================================================================================
	public void ques(int b){ // determinando as questões


		if (b == 0){
			prefabP = prefab1;
			//prefabP.SetActive (!(prefabP.activeInHierarchy));
			prefabP.transform.position = new Vector3 (-0.47f, -2.15f, 0);
		}

		if (b == 1){
			fil = prefabP;
			fil.SetActive (!(fil.activeInHierarchy));
			prefabP = prefab2;
			prefabP.SetActive (!(fil.activeInHierarchy));
			prefabP.transform.position = new Vector3 (-0.55f, -2.15f, 0);
		}

		if (b == 2){
			fil = prefabP;
			fil.SetActive (!(fil.activeInHierarchy));
			prefabP = prefab3;
			prefabP.SetActive (!(fil.activeInHierarchy));
			prefabP.transform.position = new Vector3 (-0.55f, -2.15f, 0);
		}
		if (b == 3){
			fil = prefabP;
			fil.SetActive (!(fil.activeInHierarchy));
			prefabP = prefab4;
			prefabP.SetActive (!(fil.activeInHierarchy));
			prefabP.transform.position = new Vector3 (-0.55f, -2.15f, 0);
		}


		if ((int)obj [b] == 0 ||(int)obj [b] == 6 ||(int)obj [b] == 8 ||(int)obj [b] == 9 || (int)obj [b] == 17 || (int)obj [b]== 19 || (int)obj [b] == 20 || (int)obj [b] == 22 || (int)obj [b] == 24 || (int)obj [b] == 25 || (int)obj [b] == 26 || (int)obj [b]== 27 || (int)obj [b]== 28) {
			questao.text = "QUANTOS            HÁ NO QUADRO?";
		} else {
			questao.text = "QUANTAS            HÁ NO QUADRO?";
		}

	}

	// =======================================================================
	public void opBut(int obj){ // determinando os botoes// obj = ao objeto em questão

		ques (obj);

		if (obj == 0){
			//print (o1);
			oPai = o1;
		}
		if (obj == 1){
			oPai = o2;
		}
		if (obj == 2){
			oPai = o3;
		}
		if (obj == 3){
			oPai = o4;
		}


		int n = Random.Range (1, 5);
		//print (n);
		switch (n) {
		case 1:
			b1.text = oPai.ToString();
			b2.text = (oPai + 1).ToString ();
			b3.text = (oPai + 2).ToString ();
			b4.text = (oPai - 1).ToString ();
			break;
		case 2:
			b1.text = (oPai + 1).ToString ();
			b2.text = oPai.ToString();
			b3.text = (oPai + 2).ToString ();
			b4.text = (oPai - 1).ToString ();
			break;
		case 3:
			b1.text = (oPai + 1).ToString ();
			b2.text = (oPai + 2).ToString ();
			b3.text = oPai.ToString();
			b4.text = (oPai - 1).ToString ();
			break;
		case 4:
			b1.text = (oPai + 1).ToString ();
			b2.text = (oPai + 2).ToString ();
			b3.text = (oPai - 1).ToString ();
			b4.text = oPai.ToString();
			break;
		}
	}

	//=======================================================================//=======================================================================//


	public void chama(){
		if ((aut) && (m < 3) ){
			m += 1;
			opBut (m);
			aut = false;

		}
		if (erro) {
			opBut (m);
			erro = false;
		}

	}
	public void pauseLevel(){
		//desativando os objetos
		obj1.SetActive (!(obj1).activeInHierarchy);
		obj2.SetActive (!(obj2).activeInHierarchy);
		obj3.SetActive (!(obj3).activeInHierarchy);
		obj4.SetActive (!(obj4).activeInHierarchy);
		obj5.SetActive (!(obj5).activeInHierarchy);
		pause.SetActive (!(pause).activeInHierarchy);

		if (!obj1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}

	}
}
