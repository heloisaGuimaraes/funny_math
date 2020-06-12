using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Input : MonoBehaviour {
	public Button buttonInput1;
	public Button buttonInput2;
	public Button buttonInputRes;
	public Text texto1;
	public Text texto2;
	public Text txtRes;

	public GameObject uiResposta;

	SoundPlayer soundPlayer;

	public Text txtR1;
	public Text txtR2;
	public Text txtR3;
	public Text txtR4;
	//public Text txtR;
//	public InputField mn;
	//Vector3 pos;
	int pass;
	public GameObject ob1, ob2, ob3, ob4, pause;//necessarios para o menu de pausa
	bool ok1, ok2, ok3;

	void Start () {
		ok1 = false;
		ok2 = false;
		ok3 = false;

		soundPlayer = FindObjectOfType<SoundPlayer>();
		//pass = 0;
//		mn.shouldHideMobileInput = false;

		//pos = mainInput.transform.position;
		manda.butt1= buttonInput1;
		manda.butt2 = buttonInput2;
		manda.buttRes = buttonInputRes;
		if (manda.per == 1){
			//print ("Entrou");
			manda.per = 0;
			ObjS.vzs = 0;
			ObjS2.vzs = 0;
			Dados.vzs = 0;
			Dados2.vzs = 0;
			Domino1.vzs = 0;
			Domino2.vzs = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void rept(){// Para repetir 
		if (ObjS.chG) {// Objetos da soma
			ObjS.vzs += 1;
			if (ObjS.vzs == (manda.qtdMax)) {
				ObjS.vzs = 0;
				print (ObjS.vzs);
				ObjS.vzs = 0;
				ObjS.chG = false;
				//Block2.chave4 = 1;
				if (manda.bc2 [3] != 1) {
					manda.bc2 [3] = 1;
					StartCoroutine (GoToNextScene (true, "Reforco2"));
				} else {
			
					StartCoroutine (GoToNextScene (true, "Reforco"));
				}
			} else {
				StartCoroutine (GoToNextScene (false, ""));
			}

		}else if (Dados.chG) {// Dados da soma
			Dados.vzs += 1;
			if (Dados.vzs == (manda.qtdMax)) {
				Dados.vzs = 0;
				Dados.chG = false;
				//Block2.chave3 = 1;
				manda.bc2 [2] = 1;
				//StartCoroutine (GoToNextScene (true, false));
				if (manda.blockM2 [3] == 0) {//medalha
					manda.n = 3;
					manda.blockM2 [3] = 1;
					StartCoroutine (GoToNextScene (true, "Reforco3"));
				} else {
					StartCoroutine (GoToNextScene (true, "Reforco"));
				}
			} else {
				StartCoroutine (GoToNextScene (false, ""));
			}

		}else if (Domino1.chG){//Domino soma
			Domino1.vzs += 1;
			if (Domino1.vzs == (manda.qtdMax)) {
				Domino1.vzs = 0;
				Domino1.chG = false;
				//Block2.chave2 = 1;
				if (manda.bc2 [1] != 1) {
					manda.bc2 [1] = 1;
					StartCoroutine (GoToNextScene (true, "Reforco2"));
				} else {
					StartCoroutine (GoToNextScene (true, "Reforco"));
				}
			} else {
				StartCoroutine (GoToNextScene (false, ""));
			}
		}
		else if (Domino2.chG){// Domino subtração
			Domino2.vzs += 1;
			if (Domino2.vzs == (manda.qtdMax)) {
				Domino2.vzs = 0;
				Domino2.chG = false;
				//Block3.chave2 = 1;
				if (manda.bc3 [1] != 1){
					manda.bc3 [1] = 1;
					StartCoroutine (GoToNextScene (true, "Reforco2"));
				}else {
					StartCoroutine (GoToNextScene (true, "Reforco"));
				}




			} else {
				StartCoroutine (GoToNextScene (false, ""));
			}
		}else if (Dados2.chG) {// dado subtração
			Dados2.vzs += 1;
			if (Dados2.vzs == (manda.qtdMax)) {
				Dados2.vzs = 0;
				Dados2.chG = false;
				//Block3.chave3 = 1;
				manda.bc3 [2] = 1;
				//StartCoroutine (GoToNextScene (true, "reforco"));
				if (manda.blockM2 [5] == 0) {
					manda.n = 5;
					manda.blockM2 [5] = 1;
					StartCoroutine (GoToNextScene (true, "Reforco3"));
				} else {
					StartCoroutine (GoToNextScene (true, "Reforco"));
				}

			} else {
				StartCoroutine (GoToNextScene (false, ""));
			}

		}else if (ObjS2.chG) {//Objetos da subtração
			ObjS2.vzs += 1;
			if (ObjS2.vzs == (manda.qtdMax)) {
				//print (ObjS2.vzs);
				ObjS2.vzs = 0;
				ObjS2.chG = false;
				//Block3.chave4 = 1;
				if (manda.bc3 [3] != 1) {
					
					manda.bc3 [3] = 1;
					StartCoroutine (GoToNextScene (true, "Reforco2"));	
				} else {
					StartCoroutine (GoToNextScene (true, "Reforco"));	
				}

			} else {
				StartCoroutine (GoToNextScene (false, ""));
			}

		}

	}

	private IEnumerator GoToNextScene(bool chM, string a){
		yield return new WaitForSecondsRealtime(0.65f);
		if (chM){
			
			SceneManager.LoadScene(a);// reforco

		} else {
			SceneManager.LoadScene(manda.fase);
		}
	}
	//StartCoroutine (GoToNextScene3 (false, false));

	//=========================================================================================================================
	public void cor(Button b){//muda a cor do botão para azul
		b.image.color = Color.cyan;
	}

	public void btt1(){
	//passando valores
		if (!ok1) {
			if (!(uiResposta).activeInHierarchy) {
				uiResposta.SetActive (!(uiResposta).activeInHierarchy);//ativando o botão resposta
			} 
			manda.butt2.image.color = Color.white;
			manda.buttRes.image.color = Color.white;
			cor (buttonInput1);
			valores (manda.res1);
			manda.txtGeral = texto1;
		} else {
			manda.butt1.image.color = Color.green;
			manda.butt2.image.color = Color.white;
			manda.buttRes.image.color = Color.white;
			uiResposta.SetActive (false);
		
		}
	}

	public void btt2(){
		if (!ok2) {
			if (!(uiResposta).activeInHierarchy) {
				uiResposta.SetActive (!(uiResposta).activeInHierarchy);//ativando o botão resposta
			} 
			//passando valores
			manda.butt1.image.color = Color.white;
			manda.buttRes.image.color = Color.white;
			cor (buttonInput2);
			valores (manda.res2);
			manda.txtGeral = texto2;
		}else {
			manda.butt1.image.color = Color.white;
			manda.butt2.image.color = Color.green;
			manda.buttRes.image.color = Color.white;
			uiResposta.SetActive (false);

		}
	}

	public void bttRes(){
		if (!ok3) {
			if (!(uiResposta).activeInHierarchy) {
				uiResposta.SetActive (!(uiResposta).activeInHierarchy);//ativando o botão resposta
			} 
			//passando valores
			manda.butt1.image.color = Color.white;
			manda.butt2.image.color = Color.white;
			cor (buttonInputRes);
			valores (manda.res);
			manda.txtGeral = txtRes;
		}else {
			manda.butt1.image.color = Color.white;
			manda.butt2.image.color = Color.white;
			manda.buttRes.image.color = Color.green;
			uiResposta.SetActive (false);

		}
	}

	public void textoBut(Text tt){// tt = texto do botão
		if (!manda.txtGeral.text.Equals(null)){// verifica se há um botão selecionado
			manda.txtGeral.text = tt.text.ToString (); // o quadrinho recebe o texto do meu botão
			if (manda.txtGeral == texto1) {
				//print ("txt1");
				txt1 ();
			} else if (manda.txtGeral == texto2) {
				//print ("txt2");
				txt2 ();
			} else {
				//print ("resposta");
				if (Domino1.chG || Dados.chG|| ObjS.chG){
					//print (1);
					//print ("chamou respos" );
					//print (Domino1.chG + " e "+ Dados.chG + " e "+ ObjS.chG);
				      resposta ();
				}else if (Domino2.chG || Dados2.chG||ObjS2.chG){
					//print (2);
					resposta2 ();
					//print ("chamou respos2");
				}
			}
		}

	}

	public void valores(int res){
		//definindo valores para os botoes conforme a quantidade de cada parte do domino
		int a = Random.Range(1, 5);
		switch (a) {
		case 1:
			txtR1.text = res.ToString ();
			txtR2.text = (res + 1).ToString ();
			txtR3.text = (res + 2).ToString ();
			txtR4.text = (res - 1).ToString ();
		break;

		case 2:
			txtR1.text = (res + 1).ToString ();
			txtR2.text = res.ToString ();
			txtR3.text = (res + 2).ToString ();
			txtR4.text = (res - 1).ToString ();
		break;

		case 3:
			txtR1.text = (res + 1).ToString ();
			txtR2.text = (res + 2).ToString ();
			txtR3.text = res.ToString ();
			txtR4.text = (res - 1).ToString ();
		break;

		case 4:
			txtR1.text = (res + 1).ToString ();
			txtR2.text = (res + 2).ToString ();
			txtR3.text = (res - 1).ToString ();
			txtR4.text = res.ToString ();
		break;
		}
	}


	public void txt1(){//nivel 2 - soma e subtração
		manda.txtP1 = int.Parse (texto1.text);
		//print ("ResT: " + manda.res);
		//print (manda.txtP1);
		if (manda.res1 == manda.txtP1) {
			//print ("Tt");
			manda.ch1 = true;
			buttonInput1.image.color = Color.green;
			uiResposta.SetActive (false);
			ok1 = true;
			//print (manda.ch);
			if ((manda.ch2) && (manda.ch)){
				if (Domino1.chG || Dados.chG|| ObjS.chG){
					//print (1);
					resposta ();
				}else if (Domino2.chG || Dados2.chG||ObjS2.chG){
					//print (2);
					resposta2 ();
				}
			}
		} else {
			buttonInput1.image.color = Color.cyan;
			valores (manda.res1);
			manda.ch1 = false;
		}
	}

	public void txt2(){//nivel 2 - soma e subtração
		manda.txtP2 = int.Parse (texto2.text);
		//print ("ResT: " + manda.res);
		//print (manda.txtP2);
		if (manda.res2 == manda.txtP2) {
			//print ("Tt");
			manda.ch2 = true;
			buttonInput2.image.color = Color.green;
			uiResposta.SetActive (false);
			ok2 = true;
			//print (manda.ch);
			if ((manda.ch1) && (manda.ch)){
				if (Domino1.chG || Dados.chG|| ObjS.chG){
					//print (1);
					resposta ();
				}else if (Domino2.chG || Dados2.chG||ObjS2.chG){
					//print (2);
					resposta2 ();
				}
			}

		} else {
			buttonInput2.image.color = Color.cyan;
			valores (manda.res2);
			manda.ch2 = false;

		}

	}
	public void resposta(){ // pontuação nivel 2 - soma
		manda.resTXT = int.Parse(txtRes.text);
		if (manda.res == manda.resTXT) {
			manda.buttRes.image.color = Color.green;
			uiResposta.SetActive (false);
			ok3 = true;
			manda.ch = true;
			if ((manda.txtP1 + manda.txtP2) == manda.res) {
				
				if ((manda.ch1) && (manda.ch2)) {
				manda.butt1.image.color = Color.green;
				manda.butt2.image.color = Color.green;
				manda.buttRes.image.color = Color.green;
				Pontuacao.pontos += 1;
				soundPlayer.PlayCorrect();
				//SceneManager.LoadScene(manda.fase);
				rept();// para repetir
				} else {
					if (!manda.ch1){
						manda.butt1.image.color = Color.yellow;
					} 
					if (!manda.ch2){
						manda.butt2.image.color = Color.yellow;
					}
				//manda.buttRes.image.color = Color.yellow;
					manda.ch = true;
			
			}
		 } 
		}else {
			manda.buttRes.image.color = Color.red;
			valores (manda.res);
			soundPlayer.PlayWrong();


		}
	}
	public void resposta2(){ // pontuação subtração
		manda.resTXT = int.Parse(txtRes.text);
		if (manda.res == manda.resTXT) {
			manda.buttRes.image.color = Color.green;
			uiResposta.SetActive (false);
			ok3 = true;
			manda.ch = true;
			print (manda.txtP1);
			print (manda.txtP2);
			print (manda.res);
			if ((manda.txtP1 - manda.txtP2) == manda.res) {
				if ((manda.ch1 == true) && (manda.ch2 == true)) {

				
						manda.butt1.image.color = Color.green;
						manda.butt2.image.color = Color.green;
						manda.buttRes.image.color = Color.green;
						Pontuacao.pontos += 1;
						soundPlayer.PlayCorrect();
						//SceneManager.LoadScene(manda.fase);
						rept();// para repetir
				} else {
					print ("Aqui");
					//manda.buttRes.image.color = Color.yellow;
					if (!manda.ch1){
						manda.butt1.image.color = Color.yellow;
					} 
					if (!manda.ch2){
						manda.butt2.image.color = Color.yellow;
					}
					manda.ch = true;

				}
			} 
		}else {
			manda.buttRes.image.color = Color.red;
			valores (manda.res);
			soundPlayer.PlayWrong();


		}

	}
	public void pauseLevel(){
		//desativando os objetos
		ob1.SetActive (!(ob1).activeInHierarchy);
		ob2.SetActive (!(ob2).activeInHierarchy);
		//ob3.SetActive (!(ob3).activeInHierarchy);
		//ob4.SetActive (!(ob4).activeInHierarchy);
		if (!ob1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}
		if ((uiResposta).activeInHierarchy){
			uiResposta.SetActive (!(uiResposta).activeInHierarchy);
		}
		pause.SetActive (!(pause).activeInHierarchy);

	}


}
