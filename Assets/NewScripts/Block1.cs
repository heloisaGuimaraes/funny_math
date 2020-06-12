using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Block1 : MonoBehaviour {

	public Button btn1;
	public Button btn2;
	public Button btn3;
	public Button btn4;
	public Button btn5;
	public Button btn6;

	public Sprite bauFechado;
	public Sprite bauAberto;

	public SoundPlayer soundPlayer;
	public static string[] f = new string [6];
	public  SpriteRenderer[] cad = new SpriteRenderer [6];//vetor para os cadeados
	public Sprite cadFechado;
	public Sprite cadAberto;

	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();
		Voltar.cena = "SelecionarNiveis";
		inicializaBotao();


	}
	void Update () {
		imagemBotao();
	}

	public void inicializaBotao(){

		btn1.image.sprite = bauFechado;

		btn2.image.sprite = bauFechado;

		btn3.image.sprite = bauFechado;

		btn4.image.sprite = bauFechado;

		btn5.image.sprite = bauFechado;

		btn6.image.sprite = bauFechado;


		for (int i = 0; i < 6; i++) {
			cad [i].sprite = cadFechado;
		} 


	}


	public void imagemBotao(){

		if (manda.bc1 [0] == 1){
			btn1.image.sprite = bauAberto;
			cad [0].sprite = cadAberto;
		}
		if (manda.bc1 [1] == 1){
			btn2.image.sprite = bauAberto;
			cad [1].sprite = cadAberto;
		}
		if (manda.bc1 [2] == 1){
			btn3.image.sprite = bauAberto;
			cad [2].sprite = cadAberto;
		}
		if (manda.bc1 [3] == 1){
			btn4.image.sprite = bauAberto;
			cad [3].sprite = cadAberto;
		}
		if (manda.bc1 [4] == 1){
			btn5.image.sprite = bauAberto;
			cad [4].sprite = cadAberto;
		}
		if (manda.bc1 [5] == 1){
			btn6.image.sprite = bauAberto;
			cad [5].sprite = cadAberto;
		}


	}

	public void b1(){
		if (manda.bc1 [0] == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [0]));
			//SceneManager.LoadScene (f [0]);
		}	
	}
	public void b2(){
		if (manda.bc1 [1] == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [1]));
			//SceneManager.LoadScene (f [1]);
		}	
	}
	public void b3(){
		if (manda.bc1 [2] == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [2]));
			//SceneManager.LoadScene (f [2]);
		}	
	}
	public void b4(){
		print (manda.bc1 [3]);
		if (manda.bc1 [3] == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [3]));
			//SceneManager.LoadScene (f [3]);
		}	
	}
	public void b5(){
		if (manda.bc1 [4] == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [4]));
			//SceneManager.LoadScene (f [4]);
		}	
	}
	public void b6(){
		if (manda.bc1 [5] == 1){
			soundPlayer.PlayNext ();
			StartCoroutine (GoToNextScene (f [5]));
			//SceneManager.LoadScene (f [5]);
		}	
	}

	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.3f);
		SceneManager.LoadScene(a);
	}
}
