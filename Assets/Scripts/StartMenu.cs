using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour {

	public SoundPlayer soundPlayer;

	void Start()
	{
		soundPlayer = FindObjectOfType<SoundPlayer>();
		grau ();
	}
	void update(){
	

	}
	IEnumerator GoToScene (string sceneName)
	{
		yield return new WaitForSecondsRealtime(0.55f);
		//Debug.Log("Esperando");
		if (sceneName.Equals("aaa"))
		{
			Debug.Log("Nenhuma cena selecionada");
		}
		else
		{
			SceneManager.LoadScene(sceneName);
		}
	}

	public void StartGame() {
		soundPlayer.PlayNext();
		Voltar.cena = "mainScene";
		StartCoroutine(GoToScene("SelecionarNiveis"));
	}

	public void OpenOptions(){
		soundPlayer.PlayNext();
		Voltar.cena = "mainScene";
		StartCoroutine(GoToScene("options"));
		Debug.Log("Playing sound");
	}

	public void OpenCredits(){
		//SceneManager.LoadScene ("CreditsScene");
		soundPlayer.PlayNext();
		Voltar.cena = "mainScene";
		StartCoroutine(GoToScene("creditos"));
	}

	public void QuitGame(){
		soundPlayer.PlayPrevious();
		StartCoroutine(GoToScene("aaa"));
		Application.Quit ();
	}
	public void grau(){

		if (manda.opcao == 0) {//fácil
			
			manda.qtdMax = 5;
		}else if (manda.opcao == 1) {//médio
			
			manda.qtdMax = 10;
		}else if (manda.opcao == 2) {//dificil
			
			manda.qtdMax = 15;
		}

		//print (manda.qtdMax);
	}


	public void MenuPrincipal()
	{//vai para o menu principal da fase 
		soundPlayer.PlayPrevious ();
		Voltar.cena = "SelecionarNiveis";
		StartCoroutine (GoToNextScene ("SelecionarNiveis"));
		//SceneManager.LoadScene("SelecionarNiveis");
	}

	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.3f);
		SceneManager.LoadScene(a);
	}
}
