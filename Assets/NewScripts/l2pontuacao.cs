using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class l2pontuacao : MonoBehaviour {
	//serve pro level3
	//public int resultado;
	public Text txt;
	public int res2, res1;

	SoundPlayer soundPlayer;

	// Use this for initialization
	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();
		if (manda.per == 1){
			//print ("Entrou");
			manda.per = 0;
			//print (manda.per);
			qObjetos.vzs = 0;
			MaiorMenor.qtd = 0;

			QuadroObjetos2.qtd = 0;
			QuadroObjetos3.qtd = 0;
		}
	}


	// Update is called once per frame
	void Update () {

	}

	public void pountua(){//Fase 2. /agora, 3
		if (txt.text.Equals (qObjetos.res.ToString())) {
			soundPlayer.PlayCorrect();
			qObjetos.vzs += 1;
			Pontuacao.pontos += 1;
			if (qObjetos.vzs == (manda.qtdMax)) {
				qObjetos.vzs = 0;
				if (manda.bc1 [3] != 1) {
					manda.bc1 [3] = 1; // ch4

					StartCoroutine (GoToNextScene (true, "Reforco2"));
				} else {
					StartCoroutine (GoToNextScene (true, "Reforco"));
				}

			} else {
				StartCoroutine (GoToNextScene (false, "x"));//repete a mesma fase por isso o false
			}

		}else {
			qObjetos.erro = true;
			soundPlayer.PlayWrong();

		}
	}


	public void pont(){// level 4 maior e menor que com objetos. Agora, 5
		if ((MaiorMenor.resT1 > MaiorMenor.resT2) && (txt.text.Equals (">"))) {
			soundPlayer.PlayCorrect ();
			Pontuacao.pontos += 1;
			MaiorMenor.qtd += 1;
			a ();
		} else if ((MaiorMenor.resT1 < MaiorMenor.resT2) && (txt.text.Equals ("<"))) {
			soundPlayer.PlayCorrect ();
			Pontuacao.pontos += 1;
			MaiorMenor.qtd += 1;
			a ();
		} else if ((MaiorMenor.resT1 == MaiorMenor.resT2) && (txt.text.Equals ("="))) {
			soundPlayer.PlayCorrect ();
			Pontuacao.pontos += 1;
			MaiorMenor.qtd += 1;
			a ();
		} else {
			soundPlayer.PlayWrong();
		}




	}
	public void a (){
		if (MaiorMenor.qtd == (manda.qtdMax)) {
			manda.bc1 [5] = 1; // ch6
			MaiorMenor.qtd = 0;
			if (manda.blockM2 [1] == 0) {
				manda.n = 1;
				manda.blockM2 [1] = 1;
				StartCoroutine (GoToNextScene (true, "Reforco3"));//medalha
			} else {
				StartCoroutine (GoToNextScene (true, "Reforco"));
			}


		} else {
			StartCoroutine (GoToNextScene (false, "Reforco"));
		}
	}


	public void pont6(){// level5. Agora, 6
		if ((txt.text).Equals(QuadroObjs.oPai.ToString())) {

			QuadroObjs.aut = true;
			soundPlayer.PlayCorrect();

			if (QuadroObjs.m == 5){//5
				Pontuacao.pontos +=1;
				manda.bc2 [0] = 1;//desbloqueando a fase da soma
				manda.bc3 [0] = 1;//desbloqueando a fase da subtração
			

				if (manda.blockM2 [2] == 0) {
					manda.n = 2;
					manda.blockM2 [2] = 1;// medalha
					StartCoroutine (GoToNextScene (true, "Reforco3"));
				} else {
					StartCoroutine (GoToNextScene (true, "Reforco"));
				}
			}

		} else {
			QuadroObjs.erro = true;
			soundPlayer.PlayWrong();
		}
	}


	public void pont5_1(){// level5_1
		if ((txt.text).Equals(QuadroObjetos2.oPai.ToString())) {
			QuadroObjetos2.aut = true;
			soundPlayer.PlayCorrect();
			if (QuadroObjetos2.m == 1){
				Pontuacao.pontos +=1;
				//SceneManager.LoadScene ("Level5_2");//Botar para repetir
				QuadroObjetos2.qtd +=1;
				if (QuadroObjetos2.qtd == (manda.qtdMax)) {
					QuadroObjetos2.qtd = 0;
					StartCoroutine (GoToNextScene (true, "Reforco4"));
				} else {
					StartCoroutine (GoToNextScene (false, "x"));
				}

			}

		} else {
			QuadroObjetos2.aut = false;
			QuadroObjetos2.erro = true;
			soundPlayer.PlayWrong();
		}
	}


	public void pont5_2(){// level5_2
		if ((txt.text).Equals(QuadroObjetos3.oPai.ToString())) {
			QuadroObjetos3.aut = true;
			soundPlayer.PlayCorrect();
			if (QuadroObjetos3.m == 3){
				Pontuacao.pontos +=1;
				//SceneManager.LoadScene ("Level5");//Botar para repetir
				QuadroObjetos3.qtd +=1;
				if (QuadroObjetos3.qtd == (manda.qtdMax)) {
					QuadroObjetos3.qtd = 0;
					StartCoroutine (GoToNextScene (true, "Reforco4"));
				} else {
					StartCoroutine (GoToNextScene (false, "x"));
				}
			}

		} else {
			QuadroObjetos3.aut = false;
			QuadroObjetos3.erro = true;
			//print (QuadroObjetos3.oPai.ToString());
			soundPlayer.PlayWrong();
		}
	}






	private IEnumerator GoToNextScene(bool chM, string a)
	{
		yield return new WaitForSecondsRealtime(0.65f);
		if (chM){
			SceneManager.LoadScene (a);

		} else {
			SceneManager.LoadScene (manda.fase);
		}
	}


}

