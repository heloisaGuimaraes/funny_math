using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberGenerator : MonoBehaviour {

	private int number01;
	private int number02;

    public Text number01Text;
    public Text number02Text;

    private int score;

    public int max;

    public SoundPlayer soundPlayer;
	public GameObject ob1, ob2, ob3, pause;//necessarios para o menu de pausa
	void Start () {
		
		soundPlayer.audioSource.clip = soundPlayer.l3;
		soundPlayer.audioSource.Play();

		manda.fase = "Level4";
		manda.pfase = "BlockCN";
		manda.nfase = "5 - CONHECENDO OS NÚMEROS.";
		manda.num = 5;
		if (manda.per == 1){
			
			manda.per = 0;

			score = 0;
		}

        soundPlayer = FindObjectOfType<SoundPlayer>();
		GenerateNumbers ();
	}

	private void GenerateNumbers() {
		

		number01 = Random.Range(1, max);
        number01Text.text = number01.ToString();
        //Debug.Log("N1: " + number01);

        number02 = Random.Range(1, max);
        number02Text.text = number02.ToString();
       // Debug.Log("N2: " + number02);
    }


	private void Score() {
		score++;
		Pontuacao.pontos +=1;
        max++;

        soundPlayer.PlayCorrect();
       
		if (score == (manda.qtdMax)) {
			
			if (manda.bc1 [4] != 1) {
				//print ("Entrou");
				manda.bc1 [4] = 1;// ch5
				StartCoroutine (GoToNextScene (true, "Reforco2"));
			} else {

				StartCoroutine (GoToNextScene (true, "Reforco"));
			}
			manda.bc1 [4] = 1;// ch5

		} else {
			//GenerateNumbers();
			StartCoroutine (GoToNextScene (false, ""));
		}
    }

	private IEnumerator GoToNextScene(bool chM, string a)
    {
        yield return new WaitForSecondsRealtime(0.65f);
		if (chM) {
			
			SceneManager.LoadScene (a);
		} else {
			GenerateNumbers();
		}
    }

    private void NoScore() {
		Debug.Log ("Tente novamente!\n" + "Pontuacao: " + score);

        soundPlayer.PlayWrong();
	}

	public void BiggerThan (){
		if (number01 > number02) {
			Score ();
		} else {
			NoScore ();
		}
	}

	public void LessThan (){
		if (number01 < number02) {
			Score ();
		} else {
			NoScore ();
		}
	}

	public void EqualsTo (){
		if (number01 == number02) {
			Score ();
		} else {
			NoScore ();
		}
	}

	public void pauseLevel(){//referente ao menu de pausa
		//desativando os objetos
		ob1.SetActive (!(ob1).activeInHierarchy);
		ob2.SetActive (!(ob2).activeInHierarchy);
		ob3.SetActive (!(ob3).activeInHierarchy);
		pause.SetActive (!(pause).activeInHierarchy);
		if (!ob1.activeInHierarchy) {
			soundPlayer.PlayNext ();
		} else {
			soundPlayer.PlayPrevious ();
		}

	}
}