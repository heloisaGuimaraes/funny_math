using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SecondaryMenu : MonoBehaviour {

	public SoundPlayer soundPlayer;

	public SpriteRenderer c1, c2, c3, c4;
	public Sprite cadA, cadF;
	bool sm=false, mt = false;

	void Start()
	{
		soundPlayer = FindObjectOfType<SoundPlayer>();
		Voltar.cena = "mainScene";

		if (manda.bc2 [0] == 1) {
			sm = true;
			c1.sprite = cadA;
			c2.sprite = cadA;
		} else {
			c1.sprite = cadF;
			c2.sprite = cadF;
		}

		if (manda.bf [0] == 1) {
			mt = true;
			c3.sprite = cadA;
			c4.sprite = cadA;
		} else {
			c3.sprite = cadF;
			c4.sprite = cadF;
		}
	}



	public void ConhecerOsNumeros(){
		soundPlayer.PlayNext ();
		manda.bc1 [0] = 1;

		StartCoroutine (GoToNextScene ("BlockCN"));
		//SceneManager.LoadScene ("BlockCN");
		Voltar.cena = "SelecionarNiveis";
		Block1.f[0]= "Level1";
		Block1.f[1]= "Level2_1";
		Block1.f[2]= "Level3";
		Block1.f[3]= "Level4";
		Block1.f[4]= "Level5";
		Block1.f[5]= "Level6_1";
	}

	public void Soma(){
		if (sm) {
			
			soundPlayer.PlayNext ();
			//manda.bc2 [0] = 1;
			//SceneManager.LoadScene ("BlockSM");
			Voltar.cena = "SelecionarNiveis";
			StartCoroutine (GoToNextScene ("BlockSM"));
			Block2.f [0] = "Level1Sm";
			Block2.f [1] = "Level2Sm";
			Block2.f [2] = "Level3Sm";
			Block2.f [3] = "Level4Sm";
		} 

	}

	public void Divide(){
		if (mt){
			
			soundPlayer.PlayNext ();
		//BlockFases.chave1 = 1;
		//manda.bf [0] = 1;
			BlockFases.nome = "DIVISÃO";
			BlockFases.f [0] = "Divisao";
		
		Voltar.cena = "SelecionarNiveis";
		StartCoroutine (GoToNextScene ("BlockMu_Di"));
		} 
	}

	public void Subtrai(){
		if (sm){
			
		//manda.bc3 [0] = 1;
		soundPlayer.PlayNext ();
		Voltar.cena = "SelecionarNiveis";
		StartCoroutine (GoToNextScene ("BlockSB"));
		//SceneManager.LoadScene ("BlockSB");
		Block3.f[0]= "Level1Sb";
		Block3.f[1]= "Level2Sb";
		Block3.f[2]= "Level3Sb";
		Block3.f[3]= "Level4Sb";
	} 
	}

	public void Multiplica(){
		if (mt){

		    soundPlayer.PlayNext ();
		//BlockFases.chave1 = 1;
		//manda.bf [0] = 1;
			BlockFases.nome = "MULTIPLICAÇÃO";
			BlockFases.f [0] = "Multiplicacao";
			Voltar.cena = "SelecionarNiveis";
	
			StartCoroutine (GoToNextScene ("BlockMu_Di"));
	    }
	}


	public void EscutarOsNumeros()
	{
		soundPlayer.PlayNext ();
		Voltar.cena = "SelecionarNiveis";
		StartCoroutine (GoToNextScene ("TocarNumeros"));
		//SceneManager.LoadScene("TocarNumeros");
	}



	public void MenuPrincipal()
	{//vai para o menu principal da fase 
		soundPlayer.PlayPrevious ();
		Voltar.cena = "SelecionarNiveis";
		StartCoroutine (GoToNextScene (manda.pfase));
		//SceneManager.LoadScene("SelecionarNiveis");
	}/*
    public void MenuInicial()
    {
		soundPlayer.PlayPrevious ();
		Voltar.cena = "mainScene";
		StartCoroutine (GoToNextScene ("mainScene"));
        //SceneManager.LoadScene("mainScene");
    }

	public void MenuOpcoes()
	{
		soundPlayer.PlayNext ();
		Voltar.cena = "SelecionarNiveis";
		StartCoroutine (GoToNextScene ("options"));

	}*/
	public void MenuConquistas()
	{
		soundPlayer.PlayNext ();
		Voltar.cena = "SelecionarNiveis";
		StartCoroutine (GoToNextScene ("conquistas"));

	}
	public void ReturnLevel()
	{
		soundPlayer.PlayNext ();
		StartCoroutine (GoToNextScene (manda.fase));

	}



	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.3f);
		SceneManager.LoadScene(a);
	}



}
