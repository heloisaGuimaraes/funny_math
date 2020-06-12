using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Toque: MonoBehaviour {
    // o codigo fica em todos os botoes do nivel 1 conhecendo os numeros s

    public SoundPlayer soundPlayer;

	public Text txt;
	public GameObject bot;

	 Button btt;
	public static bool tst;

	void Start () {
        soundPlayer = FindObjectOfType<SoundPlayer>();
		btt = GetComponent <Button> ();

		if (manda.per == 1){
			//print ("Entrou");
			manda.per = 0;
			//print (manda.per);
			Monitoria.qtd = 0;
			Monitoria1_1.qtd = 0;
			Monitoria1_2.qtd = 0;

			Monitoria.vzs1 = 0;
			Monitoria1_1.vzs2 = 0;
			Monitoria1_2.vzs3 = 0;


		}
		 
	}
	

	void Update () {
		
	}

	public void vToque(){

		btt.image.color = Color.yellow;
		txt.color = Color.black;
		manda.nomeP = txt.text.ToString ();
		manda.bP = bot;
		//print (manda.nomeP);

		if (manda.butP != null) {
			if (manda.butP.image.color == Color.yellow && btt.image.color == Color.yellow) {
				manda.butP.image.color = Color.blue;
				manda.txtP.color = Color.white;
			}
			if (manda.butP == btt) {
				btt.image.color = Color.yellow;
				txt.color = Color.black;
			}
		}
		manda.txtP = txt;
		manda.butP = btt;
	}


	public void cToque(){
		manda.nomeR = txt.text.ToString ();
		manda.bR = bot;
		//print (manda.nomeR);


		if (manda.nomeP.Equals (manda.nomeR)) {
			//print ("Deu");
			//Pontuacao.pontos += 1;
			manda.bP.SetActive (!(manda.bP).activeInHierarchy);//desativando o botão pergunta
			manda.bR.SetActive (!(manda.bR).activeInHierarchy);//desativando o botão resposta
                                                             
            soundPlayer.PlayCorrect();
			if (Monitoria.ch){
				
				Monitoria.vzs1 += 1;
				level1 ();

			} else if (Monitoria1_1.ch){
				Monitoria1_1.vzs2 += 1;
				level2 ();

			}else if (Monitoria1_2.ch){
				Monitoria1_2.vzs3 += 1;
				level3 ();
			}

		}
		else {
			if (!manda.nomeP.Equals ("") && !manda.nomeR.Equals ("")) {
				soundPlayer.PlayWrong();
				manda.butP.image.color = Color.blue;
				manda.txtP.color = Color.white;
			}
			manda.nomeP = "";
			manda.nomeR = "";

           


        }
		


	   }


	public void level1(){// serve para passar as fases na cenas do level 1
		//Monitoria.vzs1 +=1;
		if (Monitoria.vzs1 == 3) {
			Monitoria.ch = false;
			Monitoria.vzs1 = 0;
			Pontuacao.pontos += 1;
			Monitoria.qtd += 1;

			if (Monitoria.qtd == (manda.qtdMax)) {
				//StartCoroutine (GoToNextScene2 (manda.pfase));
				//barganha (manda.pfase);
				barganha ("Reforco4");
				Monitoria.qtd = 0;
			} else {
				//StartCoroutine (GoToNextScene2 (manda.fase));
				barganha (manda.fase);
			}
		}

	}

	public void level2(){// serve para passar as fases na cenas do level 1
		//Monitoria1_1.vzs2 +=1;
		if (Monitoria1_1.vzs2 == 6) {
			Monitoria1_1.ch = false;
			Monitoria1_1.vzs2 = 0;
			Pontuacao.pontos += 1;
			Monitoria1_1.qtd += 1;

			if (Monitoria1_1.qtd == (manda.qtdMax)) {
				//barganha (manda.pfase);
				barganha ("Reforco4");
				Monitoria1_1.qtd = 0;
			} else {
				barganha (manda.fase);
			}
		}
	}

	public void level3(){// serve para passar as fases na cenas do level 1
		//Monitoria1_2.vzs3 +=1;
		if (Monitoria1_2.vzs3 == 9) {
			Monitoria1_2.ch = false;
			Monitoria1_2.vzs3 = 0;
			Pontuacao.pontos += 1;
			Monitoria1_2.qtd += 1;
			manda.bc1 [2] = 1; // ch3

			if (Monitoria1_2.qtd == (manda.qtdMax)) {//5
				//Block1.chave2 = 1;
				if (manda.blockM2 [0] == 0) {//desbloqueando as medalhas 
					manda.n = 0;
					manda.blockM2 [0] = 1;
					barganha ("Reforco3");
				} else {
					barganha ("Reforco");
				}
				//StartCoroutine (GoToNextScene2 (true));//problemas nos botoes
				Monitoria1_2.qtd = 0;
			} else {
				barganha (manda.fase);
			}
		}
	}

	private IEnumerator GoToNextScene(){
		yield return new WaitForSecondsRealtime(2);
		//SceneManager.LoadScene("Level4");
		//Block1.chave2 = 1;
		barganha ("BlockCN");
	}


	public void barganha(string nome){// trocar de cena
		SceneManager.LoadScene (nome);
	
	}


	private IEnumerator GoToNextScene2(string n){
		yield return new WaitForSecondsRealtime(0.65f);
	
			SceneManager.LoadScene(n);


	}
	//StartCoroutine (GoToNextScene3 (false, false));
}

