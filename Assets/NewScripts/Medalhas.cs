using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class Medalhas : MonoBehaviour {
	public Sprite cA, cF;
	public SpriteRenderer image;
	public Text valor;
	public GameObject comprar, comp;
	SoundPlayer soundPlayer;


	int [] valoresM ={10, 20, 30, 40, 50, 60, 70, 80, 90};

	public GameObject[] med = new GameObject[9];

	public GameObject[] obj = new GameObject[2];
	// Use this for initialization
	void Start () {
		//image.sprite = cF;//Lembrete
		//	informacoes();
		soundPlayer = FindObjectOfType<SoundPlayer>();
	}

	// Update is called once per frame
	void Update () {
		informacoes();

		if (UnityEngine.Input.GetKeyDown (KeyCode.Escape)) {//Definindo o voltar do celular
			if (obj [1].activeInHierarchy) {
				loja ();
			}else if (obj [0].activeInHierarchy){
				soundPlayer.PlayPrevious ();
				SceneManager.LoadScene("SelecionarNiveis");

			}
		}
	}


	public void informacoes(){
		int a = manda.n;
		if (manda.blockM2 [a] == 1) {//se ja foi comprado ou não
			image.sprite = cA;
			//comp.SetActive (true);
		} else {
			image.sprite = cF;
			//comp.SetActive (false);
		}
		if (manda.blockM [a] == 1) {//se ja foi comprado ou não
			comp.SetActive (true);
		} else {
			comp.SetActive (false);
		}
		valor.text = valoresM [a].ToString ();

		if ((valoresM [a] <= Pontuacao.pontos) && (manda.blockM [a] == 0) && (manda.blockM2 [a] == 1)){
			comprar.SetActive (true);

		} else {
			comprar.SetActive (false);

		}
		controle ();
	}


	public void butComp(){
		int a = manda.n;
		if (manda.blockM2 [a]== 1){
			Pontuacao.pontos -= valoresM [a];
			manda.blockM [a] = 1;
			controle ();
		}
	}
	// o quadro de medalhas...

	public void controle(){
		for (int i = 0; i < 9; i ++){
			if (manda.blockM [i] == 1){
				med [i].SetActive (true);
			}
		}
	}


	public void loja(){//Indo e voltando da loja e quadro de medalhas

		obj [0].SetActive (!obj[0].activeInHierarchy);
		obj [1].SetActive (!obj[1].activeInHierarchy);
		if (!obj [0].activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}
	}


}
