using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SumScript : MonoBehaviour {


	public bool isUsingSum;

	public Text[] buttonText;
	public Text messageText;

	private List<int> buttonTextNumber = new List<int>();

	public Text number1Text;
	public Text number2Text;
	public Text signalText;

	private int n1;
	private int n2;
	private int n3;

	public int length = 5;
	private int correctAnswerIndex;

	public bool f1, f2, f3;
	private int qtd;
	public SoundPlayer soundPlayer;
	public GameObject ob1, ob2, pause;

	static bool soma;

	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();

		GenerateNumbers();
		GenerateAnswers();
	}

	void StartAgain()
	{
		if (manda.per == 1){
			qtd = 0; 
			manda.per = 0;

		}else if (qtd == (manda.qtdMax)) {
			if (soma) {
				//StartCoroutine (GoToNextScene ("Reforco2"));
				if (manda.blockM2 [4] == 0 && f3 == true) {//bloaqueio das medalhas
					manda.n = 4;// n da medalha
					manda.blockM2 [4] = 1;

					StartCoroutine (GoToNextScene ("Reforco3"));
					manda.pfase = "SelecionarNiveis";
				} else {
					if (f1 == true) {
						manda.pfase = "Level5Sm";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f2 == true) {
						manda.pfase = "Level6Sm";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f3 == true) {
						manda.pfase = "SelecionarNiveis";
						StartCoroutine (GoToNextScene ("Reforco"));


					}

				}

			} else {
				if (manda.blockM2 [6] == 0 && f3 == true) {
					manda.n = 6;
					manda.blockM2 [6] = 1;
					manda.pfase = "SelecionarNiveis";
					StartCoroutine (GoToNextScene ("Reforco3"));
					manda.bf [0] = 1;
				} else {
					if (f1 == true) {
						manda.pfase = "Level5Sb";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f2 == true) {
						manda.pfase = "Level6Sb";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f3 == true) {
						manda.pfase = "SelecionarNiveis";
						StartCoroutine (GoToNextScene ("Reforco"));
						manda.bf [0] = 1;
					}
				}
			}

		} else {
			length++;
			GenerateNumbers ();
			GenerateAnswers ();
		}
	}

	void GenerateNumbers()
	{
		if (isUsingSum != true)
		{
			soma = false;
			if (qtd == 0) {

				print (qtd);
				soundPlayer.audioSource.clip = soundPlayer.l4sb;
				soundPlayer.audioSource.Play ();
			}


			manda.nfase = "DE SUBTRAIR.";
			manda.fase = "Level4Sb";
			manda.pfase = "BlockSB";
			signalText.text = "-";
			messageText.text = "QUAL O RESULTADO DESTA SUBTRAÇÃO?";

			n1 = Random.Range(1, length);
			n2 = Random.Range(1, length);

			if (n2 > n1)
			{
				while (n2 > n1)
				{
					n2 = Random.Range(1, length);
				}
			}
			n3 = n1 - n2;
		}
		else {
			soma = true;
			if (qtd == 0) {
				soundPlayer.audioSource.clip = soundPlayer.l4sm;
				soundPlayer.audioSource.Play ();
			}
			manda.fase = "Level4Sm";
			manda.pfase = "BlockSM";
			manda.nfase = "DE SOMAR.";
			signalText.text = "+";
			messageText.text = "QUAL O RESULTADO DESTA SOMA?";

			n1 = Random.Range(1, length);
			n2 = Random.Range(1, length);
			n3 = n1 + n2;
		}    

		number1Text.text = n1.ToString();
		number2Text.text = n2.ToString();
	}


	void GenerateAnswers()
	{
		//int numberOfButtons = buttonText.Length;
		for (int i = 0; i < buttonText.Length; i++)
		{
			buttonTextNumber.Add(0);
		}

		for (int i = 0; i < buttonText.Length; i++)
		{
			buttonTextNumber[i] = (Random.Range(1, length * 2));
			if (buttonTextNumber[i] == n3)
			{
				while (buttonTextNumber[i] == n3)
				{
					buttonTextNumber[i] = (Random.Range(1, length * 2));
				}
			}

			buttonText[i].text = buttonTextNumber[i].ToString();
		}

		correctAnswerIndex = Random.Range(0, buttonText.Length);
		buttonText[correctAnswerIndex].text = n3.ToString();
	}

	public void verifyAnswers(int n)
	{
		if (n == correctAnswerIndex)
		{
			//Debug.Log("acertou");
			soundPlayer.PlayCorrect();
			qtd += 1;
			Pontuacao.pontos += 1;
		
			StartAgain();
		}
		else
		{
			//Debug.Log("errou");
			soundPlayer.PlayWrong();
		}
	}



	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.65f);			
		SceneManager.LoadScene(a);		
	}
	//StartCoroutine (GoToNextScene (false));


	public void pauseLevel(){
		//desativando os objetos
		ob1.SetActive (!(ob1).activeInHierarchy);
		ob2.SetActive (!(ob2).activeInHierarchy);
		pause.SetActive (!(pause).activeInHierarchy);

		if (!ob1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}

	}
}