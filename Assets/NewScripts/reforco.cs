using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reforco : MonoBehaviour {
	SoundPalms soundPalms;
	public Text txt;
	public Text txt1;
	public Text txt3;
	public SoundPlayer soundPlayer;
	public bool af;
	public bool rf;//reforço para as fases
	string[] refor = { "PARABÉNS!", "EXCELENTE!", "MUITO BEM!", "ADMIRÁVEL!", "ARRASOU!", "BACANA!", "BELEZA!", "BELÍSSIMO!", "BONITO!", "BRAVÍSSIMO!", "BRAVO!", "BRILHANTE!", "CAPRICHOU, HEIN!", "CERTÍSSIMO!", "CERTO!", "CHOCANTE!",
		"CORRETO!", "DEMAIS!", "DIGNO DE ADMIRAÇÃO!", "É ISSO AÍ!", "ENCANTADOR!", "ESPERTÍSSIMO!", "EXCEPCIONAL!", "EXTRAORDINÁRIO!", "FANTÁSTICO!", "FASCINANTE!", "FENOMENAL!", "GENIAL!", "IMPRESSIONANTE!", "LEGAL!", "MANDOU BEM!", "ÓTIMO!","PERFEITO!"};

	string[] nMed = { "PRATA", "DE OURO",  "OURO",  "BRONZE",  "PRATA",  "OURO",  "OURO",  "OURO",  "OURO"};

	// Use this for initialization
	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();
		soundPalms = FindObjectOfType<SoundPalms>();
		a ();

		soundPalms.PlayPalms ();
		if (!af) {
			txt3.text = "VOCÊ DESBLOQUEOU A FASE " + manda.nfase;
		}
		if (rf) {
			txt3.text = "VOCÊ ESTÁ FAZENDO UM BOM TRABALHO!";
		}

	}


	public void a (){
		int p = Random.Range (1,refor.Length);
		txt1.text = refor [p];
		if (!af) {
			//if (){
			txt.text = "ESCOLHA AGORA OUTRA FASE PARA JOGAR.";
		} else {
			txt.text = "VOCÊ CONQUISTOU UMA MEDALHA DE " + nMed [manda.n] + ", POR TER CUMPRIDO TODA A ATIVIDADE!";
		}
	}

	public void nextLevel(){
		soundPlayer.PlayNext ();
		StartCoroutine (GoToNextScene (manda.pfase));
		//SceneManager.LoadScene(manda.pfase);// pfase recebe o nome da cena que bloqueia

	}
	public void nextLevel2(){
		soundPlayer.PlayNext ();
		StartCoroutine (GoToNextScene (manda.pfase));
		//SceneManager.LoadScene(manda.pfase);// pfase recebe o nome da cena que bloqueia

	}
	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.3f);
		SceneManager.LoadScene(a);
	}


}
