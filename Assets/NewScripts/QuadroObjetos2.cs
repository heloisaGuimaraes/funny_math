using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadroObjetos2 : MonoBehaviour {
	// objetos
	public GameObject prefab1;
	public GameObject prefab2;

	GameObject prefabP, fil;

	public sorteioAtlas ob1;
	public sorteioAtlas ob2;


	public Text questao;
	//botoes
	public Text b1;
	public Text b2;
	public Text b3;
	public Text b4;


	float px, py;
	int o1, o2, a;
	public static int qtd;

	ArrayList obj = new ArrayList ();
	public static int m, oPai;

	public static bool aut = false, erro;
	public SoundPlayer soundPlayer;
	public GameObject obj1, obj2, obj3, obj4, obj5, pause;//necessarios para o menu de pausa

	void Start() {
		erro = false;
		if (qtd == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l5;
			soundPlayer.audioSource.Play ();
		}

		manda.fase = "Level6_1";
		manda.pfase = "Level6_2";
		manda.nfase = "6 - CONHECENDO OS NÚMEROS.";
		manda.num = 6;
		soundPlayer = FindObjectOfType<SoundPlayer>();
		sort1 ();
		instancia ();


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

			if (vzs == 2) {
				break;
			}
		}

		ob1.pos = ((int)obj [0]);
		ob2.pos = ((int)obj [1]);


	}
	// ==========================================================================================================================
	public void ques(int b){ // determinando as questões


		if (b == 0){
			prefabP = prefab1;
			//prefabP.SetActive (!(prefabP.activeInHierarchy));
			prefabP.transform.position = new Vector3 (-0.5f, -2.07f, 0);
		}

		if (b == 1){
			fil = prefabP;
			fil.SetActive (!(fil.activeInHierarchy));
			prefabP = prefab2;
			prefabP.SetActive (!(fil.activeInHierarchy));
			prefabP.transform.position = new Vector3 (-0.5f, -2.07f, 0);
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
		if ((aut) && (m < 1) ){
			m += 1;
			opBut (m);
			aut = false;

		}

		if (erro) {
			opBut (m);
			erro = false;
		}

	}

	public void instancia(){
		for ( int y = 0; y < 2; y++) {
			for (int x = -1; x < 2; x++) {
				a = Random.Range (1, 3);
				if (a == 1) {
					if (o1 == 5) {
						prefabP = prefab2;
						o2 += 1;
					} else {
						o1 += 1;
						prefabP = prefab1;
					}

				}
				else if (a == 2) {
					if (o2 == 5) {
						prefabP = prefab1;
						o1 += 1;
					} else {
						o2 += 1;
						prefabP = prefab2;
					}

				}
				//=========================
				else if (o2 == 5){
					prefabP = prefab1;
					o1 += 1;
					o2 -= 1;
				}



				if (x == -1) {
					px = (x - (0.88f));

				} 
				if (x == 0){
					px = x;
					py = (y + (0.1f));
				} 

				if (x == 1){
					px = ((x) + (0.88f));

				}
				// ===========================================================


				if (y == 0){
					py = (y + (0.2f));
				} 
				if (y == 1){
					py = (y + 0.75f);
				}


				Vector3 pos = new Vector3 (px, py, 0);
				Instantiate(prefabP, pos, Quaternion.identity);
			}
		}
		m = 0;
		opBut (m);
	}

	public void posij(){
		print (prefab1.transform.position);
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
