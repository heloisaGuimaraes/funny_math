using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monitoria1_2 : MonoBehaviour {
	// o codigo fica no GC - Nivel 1_2
	int n, n2, ax;
	ArrayList a = new ArrayList ();
	ArrayList a2 = new ArrayList ();
	/*Exemplo para não esquecer
	 * a.Add( 5);
		print (a[0]);*/
	public static int vzs3 = 0;
	public static bool ch = false;
	public static int qtd;
	//PERGUNTAS
	public Text pTxt1;
	public Text pTxt2;
	public Text pTxt3;

	public Text pTxt4;
	public Text pTxt5;
	public Text pTxt6;

	public Text pTxt7;
	public Text pTxt8;
	public Text pTxt9;

	//RESPOSTAS
	public Text nTxt1;
	public Text nTxt2;
	public Text nTxt3;

	public Text nTxt4;
	public Text nTxt5;
	public Text nTxt6;

	public Text nTxt7;
	public Text nTxt8;
	public Text nTxt9;

	public GameObject ob1, ob2, ob3, ob4, pause;//necessarios para o menu de pausa
	public SoundPlayer soundPlayer;

	// Use this for initialization
	void Start () {
		if (qtd == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l1;
			soundPlayer.audioSource.Play ();
		}

		soundPlayer = FindObjectOfType<SoundPlayer>();
		manda.fase = "Level2_3";
		manda.pfase = "BlockCN";//"Level2";
		manda.nfase = "3 - CONHECENDO OS NÚMEROS.";
		manda.num = 3;
		ch = true;

		sort1 ();//PERGUNTAS
		sort2 ();//RESPOSTAS
	}

	// Update is called once per frame
	void Update () {

	}

	public void sort1 () {
		int vzs = 0;
		while (vzs < 9){

			n = Random.Range (0, 31);
			if (!a.Contains (n)) {
				//print (n);
				a.Add (n);
				vzs += 1;
			}

		}

		pTxt1.text = (a [0]).ToString();
		pTxt2.text = (a [1]).ToString();
		pTxt3.text = (a [2]).ToString();

		pTxt4.text = (a [3]).ToString();
		pTxt5.text = (a [4]).ToString();
		pTxt6.text = (a [5]).ToString();

		pTxt7.text = (a [6]).ToString();
		pTxt8.text = (a [7]).ToString();
		pTxt9.text = (a [8]).ToString();
	}


	void sort2() {
		int vzs = 0;

		while (vzs < 9) {
			n = Random.Range (0, 9);
			if (!a2.Contains (n)) {
				//print (n);
				a2.Add (n);
				vzs += 1;
			}
		}



		ax = ((int)a2 [0]);
		nTxt1.text = (a [ax]).ToString ();
		ax = ((int)a2 [1]);
		nTxt2.text = (a [ax]).ToString ();
		ax = ((int)a2 [2]);
		nTxt3.text = (a [ax]).ToString ();

		ax = ((int)a2 [3]);
		nTxt4.text = (a [ax]).ToString ();
		ax = ((int)a2 [4]);
		nTxt5.text = (a [ax]).ToString ();
		ax = ((int)a2 [5]);
		nTxt6.text = (a [ax]).ToString ();

		ax = ((int)a2 [6]);
		nTxt7.text = (a [ax]).ToString ();
		ax = ((int)a2 [7]);
		nTxt8.text = (a [ax]).ToString ();
		ax = ((int)a2 [8]);
		nTxt9.text = (a [ax]).ToString ();
	}
	public void pauseLevel(){
		//desativando os objetos
		ob1.SetActive (!(ob1).activeInHierarchy);
		ob2.SetActive (!(ob2).activeInHierarchy);
		ob3.SetActive (!(ob3).activeInHierarchy);
		ob4.SetActive (!(ob4).activeInHierarchy);

		pause.SetActive (!(pause).activeInHierarchy);

		if (!ob1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}

	}
}
