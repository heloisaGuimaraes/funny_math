using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reforco1 : MonoBehaviour {
	SoundPalms soundPalms;
	public Text txt;
	public Text txt1;
	public Text txt3;
	public SoundPlayer soundPlayer;
	public bool af;
	string[] refor = { "Parabéns!", "Excelente!", "Muito bem!", "Admirável!", "Arrasou!", "Bacana!", "Beleza!", "Belíssimo!", "Bonito!", "Bravíssimo!", "Bravo!", "Bilhante!", "Caprichou, hein!", "Certíssimo!", "Certo!", "Chocante!",
	"Correto!", "Demais!", "Digno de admiração!", "É isso aí!", "Encantador!", "Espertíssimo!", "Excepcional!", "Extraordinário!", "Fantástico!", "Fascinante!", "Fenomenal!", "Genial!", "Impressionante!", "Legal!", "Mandou bem!", "Ótimo!","Perfeito!"};

	string[] nMed = { "de prata", "de ouro",  "de ouro",  "de bronze",  "de prata",  "de ouro",  "de ouro",  "de ouro",  "de ouro"};

	// Use this for initialization
	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();
		soundPalms = FindObjectOfType<SoundPalms>();
		a ();

		soundPalms.PlayPalms ();
		if (!af) {
			txt3.text = "Você concluiu a fase " + manda.nfase;
		}

	}


	public void a (){
		int p = Random.Range (1,refor.Length);
		txt1.text = refor [p];
		if (!af) {
			//if (){
			txt.text = "Jogue agora a fase " + manda.nfase;
		} else {
			txt.text = "Você desbloqueou uma medalha de " + nMed [manda.n] + ", por ter cumprido toda a atividade!";
		}
	}

	public void nextLevel(){
		soundPlayer.PlayNext ();
		StartCoroutine (GoToNextScene (manda.pfase));
		//SceneManager.LoadScene(manda.pfase);// pfase recebe o nome da cena que bloqueia

	}
	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.3f);
		SceneManager.LoadScene(a);
	}


}
