using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Monitoria : MonoBehaviour {
	// o codigo fica no GC - Nivel 1
	int n, n2, ax;
	ArrayList a = new ArrayList ();
	ArrayList a2 = new ArrayList ();
	public static int vzs1 = 0;
	public static bool ch = false;

	public static int qtd;

	public GameObject ob1, ob2, ob3, ob4, pause;//necessarios para o menu de pausa
	/*Exemplo para não esquecer
	 * a.Add(5);
		print (a[0]);*/
	
	//PERGUNTAS
	public Text nTxt1;
	public Text nTxt2;
	public Text nTxt3;

	//RESPOSTAS
	public Text nTxt4;
	public Text nTxt5;
	public Text nTxt6;

	public Text nTxt7;
	public Text nTxt8;
	public Text nTxt9;
	public SoundPlayer soundPlayer;
	// Use this for initialization
	void Start () {
		
		if (qtd == 0) {
			soundPlayer.audioSource.clip = soundPlayer.l1;
			soundPlayer.audioSource.Play ();
		}
        soundPlayer = FindObjectOfType<SoundPlayer>();
		manda.fase = "Level2_1";
		manda.pfase = "Level2_2";
		manda.nfase = "3 - CONHECENDO OS NÚMEROS.";
		manda.num = 3;
		//BlockFases.chave1 = true;// Colocar Permanete

		ch = true;
		//qtd = 0;
		sort1 ();//PERGUNTAS
		sort3 ();//RESPOSTAS

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void sort1 () {
		int vzs = 0;
		while (true) {
			
			n = Random.Range (0, 11);
			if (!a.Contains (n)) {
				a.Add (n);
				vzs += 1;
			}

			if (vzs == 3) {
				break;
			}
		}

		nTxt1.text = (a [0]).ToString();
		nTxt2.text = (a [1]).ToString();
		nTxt3.text = (a [2]).ToString();

	}




	void sort3 () {
		int vzs = 0;
		sort1 ();
		while (true) {

			n2 = Random.Range (0, 6);
			if (!a2.Contains (n2)) {
				a2.Add (n2);
				vzs += 1;
			}

			if (vzs == 6) {
				break;
			}
		}
		//ax = ((int)a2 [0]);
		nTxt4.text = (a [(int)a2 [0]]).ToString ();
		ax = ((int)a2 [1]);
		nTxt5.text = (a [ax]).ToString ();
		ax = ((int)a2 [2]);
		nTxt6.text = (a [ax]).ToString ();

		ax = ((int)a2 [3]);
		nTxt7.text = (a [ax]).ToString ();
		ax = ((int)a2 [4]);
		nTxt8.text = (a [ax]).ToString ();
		ax = ((int)a2 [5]);
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
