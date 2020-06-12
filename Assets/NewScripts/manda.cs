using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manda : MonoBehaviour {
	//faço as comparações para pontuar
	public static string nomeP = "";//pergunta dos botoes do nivel 1 (que eu lembre)
	public static string nomeR = "";//respostaa

	public static GameObject bP;//pergunta
	public static GameObject bR;//resposta

	public static Button butt1;//fases de soma e subtração
	public static Button butt2;//fases de soma e subtração

	public static Button butP;
	public static Text txtP;

	public static Button buttRes;//fases de soma e subtração
	public static Text txtGeral;
	// variaveis para as cenas do domino e dado
	public static int txtP1;//pergunta1
	public static int txtP2;//pergunta2
	public static int res;//res
	public static bool ch1, ch2, ch;

	public static int resTXT;//res
	public static int res1;
	public static int res2;
	public static string fase;
	public static string pfase;
	public static string nfase;

	public static int vlr;//fase 2
	public static int c; // escolhendo o objeto para o atlas

	//public GameObject level, pause;
	public static int [] blockM = new int[9]; // bloqueio das medalhas
	public static int [] blockM2 = new int[9]; // bloqueio das medalhas, cadeado
	public static int per;//variavel de permissao para zerar as quantidades ao repetir a frase 

	public static int [] bc1 = new int[6];
	public static int [] bc2 = new int[6];
	public static int [] bc3 = new int[6];
	public static int [] bf = new int[6];
	string a;
	public static int n;
	public static int num;//variavel onde as fases definiram o numero da fase debloqueada
	public static int qtdMax;//quantidade maxima para a repetição de todas as fases
	public static int opcao; // numero da opção do grau de dificuldade
	// Use this for initialization
	void Start () {
		txtP1 = 0;
		txtP2 = 0;
		//res = 0;
		ch1 = false;
		ch2 = false;
		ch = false;
		per = PlayerPrefs.GetInt ("permissao", per);

		qtdMax = PlayerPrefs.GetInt ("quantidade", qtdMax);
		opcao = PlayerPrefs.GetInt ("opcao", opcao);

		c = Random.Range (0, 28);

		blockM[0] = PlayerPrefs.GetInt ("m0", blockM[0]);
		blockM[1] = PlayerPrefs.GetInt ("m1", blockM[1]);
		blockM[2] = PlayerPrefs.GetInt ("m2", blockM[2]);
		blockM[3] = PlayerPrefs.GetInt ("m3", blockM[3]);
		blockM[4] = PlayerPrefs.GetInt ("m4", blockM[4]);
		blockM[5] = PlayerPrefs.GetInt ("m5", blockM[5]);
		blockM[6] = PlayerPrefs.GetInt ("m6", blockM[6]);
		blockM[7] = PlayerPrefs.GetInt ("m7", blockM[7]);
		blockM[8] = PlayerPrefs.GetInt ("m8", blockM[8]);


		for (int i = 0; i < blockM2.Length; i++){
			a = "cd"+i.ToString();
			blockM2 [i] = PlayerPrefs.GetInt (a, blockM2 [i]);	
		}
		//bloqueio das fases
		//conhecendo os numeros

		for (int i = 0; i < 6; i++){
			a = "bc"+i.ToString();
			bc1 [i] = PlayerPrefs.GetInt (a, bc1 [i]);	
		}
		// soma
		for (int i = 0; i < 5; i++){
			a = "2bc"+i.ToString();
			bc2 [i] = PlayerPrefs.GetInt (a, bc2 [i]);	
		}
		// subtração
		for (int i = 0; i < 5; i++){
			a = "3bc"+i.ToString();
			bc3 [i] = PlayerPrefs.GetInt (a, bc3 [i]);	
		}
		//for (int i = 0; i < 1; i++){
		//	a = "3bc"+i.ToString();
			bf [0] = PlayerPrefs.GetInt ("bf", bf [0]);	
		//}




	}

	void Update () {
		PlayerPrefs.SetInt ("permissao", per);


		PlayerPrefs.SetInt ("m0", blockM [0]);
		PlayerPrefs.SetInt ("m1", blockM [1]);
		PlayerPrefs.SetInt ("m2", blockM [2]);
		PlayerPrefs.SetInt ("m3", blockM [3]);
		PlayerPrefs.SetInt ("m4", blockM [4]);
		PlayerPrefs.SetInt ("m5", blockM [5]);
		PlayerPrefs.SetInt ("m6", blockM [6]);
		PlayerPrefs.SetInt ("m7", blockM [7]);
		PlayerPrefs.SetInt ("m8", blockM [8]);

		PlayerPrefs.SetInt ("quantidade", qtdMax);
		PlayerPrefs.SetInt ("opcao", opcao);

		for (int i = 0; i < blockM.Length; i++){
			a = "cd"+ i.ToString();
			PlayerPrefs.SetInt (a, blockM2 [i]);
		}
		//bloqueio das fases
       //conhecendo os numeros

		for (int i = 0; i < 6; i++){
			a = "bc"+ i.ToString();
			PlayerPrefs.SetInt (a, bc1 [i]);
		}
		//soma
		for (int i = 0; i < 6; i++){
			a = "2bc"+ i.ToString();
			PlayerPrefs.SetInt (a, bc2 [i]);
		}

		//subtração
		for (int i = 0; i < 6; i++){
			a = "3bc"+ i.ToString();
			PlayerPrefs.SetInt (a, bc3 [i]);
		}

		PlayerPrefs.SetInt ("bf", bf [0]);

	}


}
