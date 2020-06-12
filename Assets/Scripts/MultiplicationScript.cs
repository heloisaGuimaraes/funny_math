using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplicationScript : MonoBehaviour {

	public bool isUsingMultiplication;

	public Text[] buttonText;
	public Text messageText;

	private List<int> buttonTextNumber = new List<int>();

	public Text number1Text;
	public Text number2Text;
	public Text signalText;

	private int n1;
	private int n2;
	private int n3;
	public bool f1, f2, f3;
	public int length = 5;
	private int correctAnswerIndex;

	private int qtd;
	public static bool divisao;
	public SoundPlayer soundPlayer;
	public GameObject ob1, ob2, pause;
	// Use this for initialization
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
		} else if (qtd == (manda.qtdMax)){
			//StartCoroutine (GoToNextScene ("Reforco2"));
			if (isUsingMultiplication == true ) {// == multiplicação
				if (manda.blockM2 [7] == 0 && f3 == true) {
					manda.n = 7;
					manda.blockM2 [7] = 1;
					manda.pfase = "SelecionarNiveis";
					StartCoroutine (GoToNextScene ("Reforco3"));

				} else {
					if (f1) {
						manda.pfase = "Multiplicacao_2";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f2) {
						manda.pfase = "Multiplicacao_3";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f3) {
						manda.pfase = "SelecionarNiveis";
						StartCoroutine (GoToNextScene ("Reforco"));//  OLHAR
					}
				}
			} else {
				if (manda.blockM2 [8] == 0 && f3 == true) {
					manda.n = 8;
					manda.blockM2 [8] = 1;
					manda.pfase = "SelecionarNiveis";
					StartCoroutine (GoToNextScene ("Reforco3"));


				} else {
					if (f1) {
						manda.pfase = "Divisao_2";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f2) {
						manda.pfase = "Divisao_3";
						StartCoroutine (GoToNextScene ("Reforco4"));
					}else if (f3) {
						manda.pfase = "SelecionarNiveis";
						StartCoroutine (GoToNextScene ("Reforco"));//  OLHAR
					}

				}
			}
			//

		} else {
			length++;
			GenerateNumbers();
			GenerateAnswers();
		}
	}

	void GenerateNumbers()
	{
		if (isUsingMultiplication != true)
		{
			divisao = true;
			if (qtd == 0) {
				print (qtd);
				soundPlayer.audioSource.clip = soundPlayer.div;
				soundPlayer.audioSource.Play();
			}
			manda.fase = "divisao";
			manda.nfase = "DE DIVIDIR.";
			signalText.text = ":";
			messageText.text = "QUAL O RESULTADO DESTA DIVISÃO?";

			n1 = Random.Range(1, length  * 2);
			n2 = Random.Range(1, length);

			if ((n1 % n2) != 0)
			{
				while ((n1 % n2) != 0)
				{
					n2 = Random.Range(1, length);
				}
			}
			n3 = n1 / n2;
		}
		else {
			divisao = false;
			if (qtd == 0) {

				soundPlayer.audioSource.clip = soundPlayer.mult;
				soundPlayer.audioSource.Play();
			}
			//soundPlayer.audioSource.clip = soundPlayer.mult;
			//	soundPlayer.audioSource.Play();
			manda.fase = "multiplicacao";
			manda.nfase = "DE MULTIPLICAR.";
			signalText.text = "x";
			messageText.text = "QUAL O RESULTADO DESTA MULTIPLICAÇÃO?";

			n1 = Random.Range(1, length);
			n2 = Random.Range(1, length);
			n3 = n1 * n2;
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

		for (int i = 0; i < buttonText.Length; i ++)
		{
			if (isUsingMultiplication == false)
			{
				buttonTextNumber[i] = (Random.Range(1, length));
				if (buttonTextNumber[i] == n3)
				{
					while (buttonTextNumber[i] == n3)
					{
						buttonTextNumber[i] = (Random.Range(1, length));
					}
				}
			}
			else
			{
				buttonTextNumber[i] = (Random.Range(1, length * length));
				if (buttonTextNumber[i] == n3)
				{
					while (buttonTextNumber[i] == n3)
					{
						buttonTextNumber[i] = (Random.Range(1, length * 2));
					}
				}
			}


			buttonText[i].text = buttonTextNumber[i].ToString();
			//Debug.Log("Botao " + (i + 1) + ", valor: " + buttonTextNumber[i]);
		}

		correctAnswerIndex = Random.Range(0, buttonText.Length);
		//Debug.Log("Botao correto: " + correctAnswerIndex);
		buttonText[correctAnswerIndex].text = n3.ToString();
	}

	public void verifyAnswers(int n)
	{
		if (n == correctAnswerIndex)
		{
			//Debug.Log("acertou");
			Pontuacao.pontos += 1;
			qtd +=1;
			soundPlayer.PlayCorrect();
			StartAgain();
		}
		else
		{
			// Debug.Log("errou");
			soundPlayer.PlayWrong();
		}
	}

	void Update () {

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