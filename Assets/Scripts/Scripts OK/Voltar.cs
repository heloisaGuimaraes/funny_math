using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour {
	public static string cena;//Variavel para guardar o nome da cena que os botoes vão fornecer
	public SoundPlayer soundPlayer;

	void Start()
	{
		soundPlayer = FindObjectOfType<SoundPlayer>();


	}
	public void Update (){
		if (UnityEngine.Input.GetKeyDown (KeyCode.Escape)) {
			//Application.Quit ();
			soundPlayer.PlayPrevious ();
			StartCoroutine (GoToNextScene (cena));

		}

	}

	private IEnumerator GoToNextScene(string a){
		yield return new WaitForSecondsRealtime(0.3f);
		SceneManager.LoadScene(a);
	}

}
