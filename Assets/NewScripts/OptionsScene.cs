using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScene : MonoBehaviour {

	public Sprite soundOn;
	public Sprite soundOff;

	public Button butSound;
	public SoundPlayer soundPlayer;

	void Start () {
		soundPlayer = FindObjectOfType<SoundPlayer>();
	}

	// Update is called once per frame
	void Update () {
		btn ();
	}

	public void btn(){
		if (SoundPlayer.chSP == 1) {//esta ativo
			//print ("On");
			butSound.image.sprite = soundOn;
		} else {
			//print ("Off");
			butSound.image.sprite = soundOff;
		}

	}

	public void chS(){
		if (SoundPlayer.chSP == 1) {
			SoundPlayer.chSP = 0;
			//print (0);
		} else {
			SoundPlayer.chSP = 1;
			//print (1);
		}

		btn ();
	}

	private IEnumerator GoToNextScene(string n){
		yield return new WaitForSecondsRealtime(0.6f);

		SceneManager.LoadScene(n);

	}
	//StartCoroutine (GoToNextScene ());

	public void repetir(){
		soundPlayer.PlayNext ();
		manda.per = 1;
		StartCoroutine (GoToNextScene (manda.fase));
	}


}
