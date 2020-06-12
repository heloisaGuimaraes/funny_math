using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class idNumero : MonoBehaviour {
	public Text txtNome;// text publico que recebe o text da cena
	private string temp;// variavel para receber temporariamente o nome dos numeros

	public string[] numbers_nome;// vetor com o nome dos números
	private int num;// variavel para receber o número sorteado

	public Text[] btText;// vetor para receber os textos dos botoes
	public SoundPlayer soundPlayer;
	int cont = 0; //variavel para auxiliar nos bloqueios dos botoes
	int a, b, c;// a = ao limite do sorteio, b e c valem as posições dos texts
	public GameObject b3, b4, b5;// var. para a controle dos botoes na cena



	public GameObject ob1, pause;
	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();
		manda.fase = "Level1";// nome da fase atual
		manda.pfase = "BlockCN";// nome da próxima fase
		manda.nfase = "2 - CONHECENDO OS NÚMEROS.";
		manda.num = 2;
		inicio ();
		//print (cont);
	}

	void Update () {
		
	}
	//==========================================
	void inicio(){


			num = Random.Range (0, 31);// sorteio do núm



		cont +=1;
		temp = numbers_nome [num];// pegando o nome no vetor
		txtNome.text = temp.ToString ();
		soundPlayer.PlayNumber(num);//reproduzindo o nome

		if (cont <= (manda.qtdMax)) {//5
			a = 3;
			b3.SetActive (false);
			b4.SetActive (false);
			b5.SetActive (false);
			b = 4;
			c = 4;
		} else if (cont > (manda.qtdMax) && cont <= (manda.qtdMax * 2)) {// 5 e 10
			
			a = 4;
			b3.SetActive (false);
			b4.SetActive (false);
			b5.SetActive (true);
			b = 4;// txt do botão central
			c = 3;
		} else if (cont > (manda.qtdMax * 2) && cont <= (manda.qtdMax * 3)) {//10 e 15 
			
			a = 5;
			b3.SetActive (true);
			b4.SetActive (true);
			b5.SetActive (false);
			b = 2;
			c = 3;
		} 

		valores ();
	}


	public void valores(){// definindo valores para os botoes
		int z = Random.Range(1, a);
		switch (z) {
		case 1:
			btText [0].text = num.ToString ();
			btText [1].text = (num + 1).ToString ();
			btText [b].text = (num + 2).ToString ();
			btText [c].text = (num - 1).ToString ();
			break;

		case 2:
			btText[0].text = (num + 1).ToString ();
			btText[1].text = num.ToString ();
			btText[b].text = (num + 2).ToString ();
			btText[c].text = (num - 1).ToString ();
			break;

		case 3:
			btText[0].text = (num + 1).ToString ();
			btText[1].text = (num + 2).ToString ();
			btText[b].text = num.ToString ();
			btText[c].text = (num - 1).ToString ();
			break;

		case 4:
			btText[0].text = (num + 1).ToString ();
			btText[1].text = (num + 2).ToString ();
			btText[b].text = (num - 1).ToString ();
			btText[c].text = num.ToString ();
			break;
		}
	}



	//========================================== Botões==========================================
	public void ouvir(){//função basiquinha para ouvir o som novamente
		soundPlayer.PlayNumber(num);
	}

	public void verificarResposta(Text txt){
		int x = int.Parse (txt.text);
		if (x == num) {
			Pontuacao.pontos += 1;
			soundPlayer.PlayCorrect ();
			//StartCoroutine (GoToNextScene2 ());

			//print ("PONTO!");
			if (cont >= (manda.qtdMax * 3)) {
				cont = 0;

				if (manda.bc1 [1] != 1) { // ch2
					manda.bc1 [1] = 1;//ch 2
					StartCoroutine (GoToNextScene ("Reforco2"));

				} else {
					StartCoroutine (GoToNextScene ("Reforco"));

				}
				manda.bc1 [1] = 1;//ch 2
			} else {
				inicio ();
				//print (cont);
			}
		} else {
			soundPlayer.PlayWrong ();
		}
	}

	//====
	private IEnumerator GoToNextScene(string a ){
		yield return new WaitForSecondsRealtime(0.65f);
	
		SceneManager.LoadScene (a);

	}
	private IEnumerator GoToNextScene2(){
		yield return new WaitForSecondsRealtime(0.65f);



	}
	public void pauseLevel(){
		//desativando os objetos
		ob1.SetActive (!(ob1).activeInHierarchy);

		pause.SetActive (!(pause).activeInHierarchy);

		if (!ob1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}

	}



}
