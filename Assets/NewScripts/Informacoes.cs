using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Informacoes : MonoBehaviour {
	//level 6
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	public GameObject prefab4;
	public GameObject prefab5;
	public GameObject prefab6;
	GameObject prefabP, fil;

	public sorteioAtlas ob1;
	public sorteioAtlas ob2;
	public sorteioAtlas ob3;
	public sorteioAtlas ob4;
	public sorteioAtlas ob5;
	public sorteioAtlas ob6;
	public sorteioAtlas ob7;

	public Text questao;

	public Text b1;
	public Text b2;
	public Text b3;
	public Text b4;


	float px, py;
	private int a;

	ArrayList obj = new ArrayList ();
	public static int m, oPai;

	public static bool aut = false;
	ArrayList posN = new ArrayList ();
	public int max;

	public static int numLugar;
	void Start() {
		manda.fase = "Level6_1";
		//manda.pfase = "BlockCN";
		//manda.nfase = "6 - Conhecendo os números.";

		sort1 ();
		m = 0;// identificando o objeto em questao
		opBut (m);

	}


	// ===========================================================
	public void sort1 () {//para escolher os sprites
		int vzs = 0;
		int n;
		while (vzs < 6) {

			n = Random.Range (0, 28);
			if (!obj.Contains (n)) {
				//print (n);
				obj.Add (n);
				vzs += 1;
			}

			if (vzs == 6) {
				break;
			}
		}

		ob1.pos = ((int)obj [0]);
		ob2.pos = ((int)obj [1]);
		ob3.pos = ((int)obj [2]);
		ob4.pos = ((int)obj [3]);
		ob5.pos = ((int)obj [4]);
		ob6.pos = ((int)obj [5]);

		vzs = 0;
		while (vzs < 6) {//determinado os numeros 
			n = Random.Range (1, max);
			if (!posN.Contains (n)) {
				print (n);
				posN.Add (n);
				vzs += 1;
			}
		}


	}
	// =======================================================================
	public void opBut(int obj){ // determinando os botoes// obj = ao objeto em questão

		ques (obj);
		oPai = ((int)posN [0]);
		//print (oPai);

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
	public void ques(int b){ // determinando as questões

			ob7.pos = ((int)obj [b]);// b é a posição para identifocar no vetor

		if ((int)obj [b] == 0 ||(int)obj [b] == 6 ||(int)obj [b] == 8 ||(int)obj [b] == 9 || (int)obj [b] == 17 || (int)obj [b]== 19 || (int)obj [b] == 20 || (int)obj [b] == 22 || (int)obj [b] == 24 || (int)obj [b] == 25 || (int)obj [b] == 26 || (int)obj [b]== 27 || (int)obj [b]== 28) {
			questao.text = "Quantos             há no quadro acima?";
		} else {
			questao.text = "Quantas             há no quadro acima?";
		}

		//float a = posNumX ((int)posN[b]);
		//float b2 = posNumY ((int)posN[b]);

	}


	public void chama(){
		if ((aut) && (m < 5) ){
			m += 1;
			opBut (m);
			aut = false;

		}
	}

	public float posNumX(int num){
		if (num ==1 ||num ==6 ||num ==11 ||num ==16 ||num ==21 ||num ==26){//determinando o x
			print ("-2.2");
			return (-2.2f);
			
		}else if (num ==2 ||num ==7 ||num ==12 ||num ==17 ||num ==22 ||num ==27){
			return (-1.1f);

		}else if (num ==3 ||num ==8 ||num ==13 ||num ==18 ||num ==23 ||num ==28){
			print ("0");
			return (0);

		}else if (num ==4 ||num ==9 ||num ==14 ||num ==19 ||num ==24 ||num ==29){
			print ("1.1");
			return (1.1f);

		}else if (num ==5 ||num ==10 ||num ==15 ||num ==20 ||num ==25 ||num ==30){
			print ("2.2");
			return (2.2f);

		}
		return 0;
	}
	public float posNumY(int num){
		if (num >=1 && num <= 5){//determinando o x
			print ("0.55");
			return (0.55f);
		}else if (num >=6 && num <= 10){//determinando o x
			print ("-0.6");
			return -0.6f;
		}
		return 0;
	}


}
