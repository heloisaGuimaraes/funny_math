using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    public AudioClip next;
    public AudioClip previous;
    public AudioClip correct;
    public AudioClip wrong;

    public AudioClip div, l1, l2, l3, l4, l5, l1sm, l2sm, l3sm, l4sm, l1sb, l2sb, l3sb, l4sb, mult, reforco, parabens, muitoBem;

	public static int chSP = 1;
    //public AudioClip[] audioClip = new AudioClip[10];

    public AudioClip[] numbers;
    public AudioClip[] signals;

    public AudioSource audioSource;

    public int number;

    void Start () {
        //audioSource = FindObjectOfType<Camera>();
		chSP = PlayerPrefs.GetInt ("chave", chSP);
	}
	
	void Update () {
		PlayerPrefs.SetInt ("chave", chSP);
    }

    public void PlayNumber(int num)
    {
		
			audioSource.clip = numbers [num];
			Play ();

			//Debug.Log ("num");
	}

    public void PlaySignal(int num)
    {
		
			audioSource.clip = signals [num];
			Play ();

    }
    public void PlayNext()
    {
		if (chSP == 1) {
        audioSource.clip = next;
        Play();
        //StartCoroutine(Play());
		}
    }

    public void PlayPrevious()
    {
		if (chSP == 1) {
			audioSource.clip = previous;
			Play ();
		}
    }

    public void PlayCorrect()
    {
		if (chSP == 1) {
			audioSource.clip = correct;
			Play ();
		}
    }

    public void PlayWrong()
    {
		if (chSP == 1) {
			audioSource.clip = wrong;
			Play ();
		}
    }

    void Play()
    {
		
        audioSource.Play();
        //yield return new WaitForSecondsRealtime(0.5f);
        //Debug.Log("Exit button has been pressed. Leaving Application");

    }
}