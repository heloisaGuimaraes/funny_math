using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BlockFases : MonoBehaviour {
	public Button btn1;
	/*public Button btn2;
	public Button btn3;
	public Button btn4;
	public Button btn5;
	public Button btn6;
*/
	public Sprite bauFechado;
	public Sprite bauAberto;

	public static string nome;
	public Text txt;

	/*public static int chave1;
	public static int chave2;
	public static int chave3;
	public static int chave4;
	public static int chave5;
	public static int chave6;

*/
	public SoundPlayer soundPlayer;
	public static string[] f = new string [1];//6];
	public  SpriteRenderer[] cad = new SpriteRenderer [1];//vetor para os cadeados
	public Sprite cadFechado;
	public Sprite cadAberto;

	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();
		txt.text = nome.ToString ();
		Voltar.cena = "SelecionarNiveis";

		/*
		chave1 = PlayerPrefs.GetInt ("ch1", chave1);
		chave2 = PlayerPrefs.GetInt ("ch2", chave2);
		chave3 = PlayerPrefs.GetInt ("ch3", chave3);
		chave4 = PlayerPrefs.GetInt ("ch4", chave4);
		chave5 = PlayerPrefs.GetInt ("ch5", chave5);
		chave6 = PlayerPrefs.GetInt ("ch6", chave6);*/
		inicializaBotao();

	}
	void Update () {
		/*
		PlayerPrefs.SetInt ("ch1", chave1);
		PlayerPrefs.SetInt ("ch2", chave2);
		PlayerPrefs.SetInt ("ch3", chave3);
		PlayerPrefs.SetInt ("ch4", chave4);
		PlayerPrefs.SetInt ("ch5", chave5);
		PlayerPrefs.SetInt ("ch6", chave6);*/
		imagemBotao();
	}

	public void inicializaBotao(){
		
		btn1.image.sprite = bauFechado;
		/*
		btn2.image.sprite = bauFechado;

		btn3.image.sprite = bauFechado;

		btn4.image.sprite = bauFechado;

		btn5.image.sprite = bauFechado;

		btn6.image.sprite = bauFechado;*/
		for (int i = 0; i < 1; i++) {
			cad [i].sprite = cadFechado;
		} 


	}


	public void imagemBotao(){
		
		if (manda.bf [0] == 1){
			btn1.image.sprite = bauAberto;
			cad [0].sprite = cadAberto;
		} 
		/*if (chave2 == 1){
			btn2.image.sprite = bauAberto;
			cad [1].sprite = cadAberto;//Se ativir, expandir
		}
		if (chave3 == 1){
			btn3.image.sprite = bauAberto;
		}
		if (chave4 == 1){
			btn4.image.sprite = bauAberto;
		}
		if (chave5 == 1){
			btn5.image.sprite = bauAberto;
		}
		if (chave6 == 1){
			btn6.image.sprite = bauAberto;
		}*/
	}

	public void b1(){
		if (manda.bf [0] == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [0]));
			//SceneManager.LoadScene (f [0]);
		}	
	}
	/*
     public void b2(){
		if (chave2 == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [1]));
			//SceneManager.LoadScene (f [1]);
		}	
	}
	public void b3(){
		if (chave3 == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [2]));
			//SceneManager.LoadScene (f [2]);
		}	
	}
	public void b4(){
		if (chave4 == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [3]));
			//SceneManager.LoadScene (f [3]);
		}	
	}
	public void b5(){
		if (chave5 == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [4]));
			//SceneManager.LoadScene (f [4]);
		}	
	}
	public void b6(){
		if (chave6 == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [5]));
			//SceneManager.LoadScene (f [5]);
		}	
	}

*/
	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.3f);
		SceneManager.LoadScene(a);
	}
}
