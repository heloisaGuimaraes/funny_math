using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WriteNumbers : MonoBehaviour {

	public Text writtenNumber;
	private string temp;

	public string[] numbers;
	public string[] signalsName;

	public SoundPlayer soundPlayer;

	public GameObject a1;
	public GameObject a2;
	public GameObject a3;
	public GameObject signals;

	public GameObject btP;
	public GameObject btN;
	private int selector = 0;

	void Start () {
		writtenNumber.text = "CLIQUE EM UM SÍMBOLO.";
		soundPlayer = FindObjectOfType<SoundPlayer>();
		Voltar.cena = "SelecionarNiveis";
	}

	void Update()
	{
		if (selector == 0)
		{
			//writtenNumber.text = "Clique em um símbolo.";
			a1.SetActive(false);
			a2.SetActive(false);
			a3.SetActive(false);
			signals.SetActive(true);

			btP.SetActive (false);
			btN.SetActive (true);
		}
		if (selector == 1)
		{// 0 a 9
			//writtenNumber.text = "Clique em um número.";
			a1.SetActive(true);
			a2.SetActive(false);
			a3.SetActive(false);
			signals.SetActive(false);

			btP.SetActive (true);
			btN.SetActive (true);
		}
		else if (selector == 2)
		{
			//writtenNumber.text = "Clique em um número.";
			a1.SetActive(false);
			a2.SetActive(true);
			a3.SetActive(false);
			signals.SetActive(false);

			btP.SetActive (true);
			btN.SetActive (true);

		}
		else if (selector == 3)
		{
			//writtenNumber.text = "Clique em um número.";
			a1.SetActive(false);
			a2.SetActive(false);
			a3.SetActive(true);
			signals.SetActive(false);

			btP.SetActive (true);
			btN.SetActive (false);
		}
	}

	public void GoToNext()
	{
		writtenNumber.text = "CLIQUE EM UM SÍMBOLO.";
		if (selector < 3)
		{
			selector++;
		}
	}

	public void GoToPrevious()
	{
		writtenNumber.text = "CLIQUE EM UM SÍMBOLO.";
		if (selector > 0){
			selector--;
		}
	}

	public void WriteANumber(int num)
	{
		temp = numbers[num];
		writtenNumber.text = temp.ToString();
		//Debug.Log(temp);

		soundPlayer.PlayNumber(num);
	}

	public void WriteASignal(int num)
	{
		temp = signalsName[num];
		writtenNumber.text = temp.ToString();

		soundPlayer.PlaySignal(num);
	}

	public void Back()
	{
		SceneManager.LoadScene("SelecionarNiveis");
	}
}