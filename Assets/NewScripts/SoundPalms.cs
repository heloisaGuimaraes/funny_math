using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPalms : MonoBehaviour {
	public AudioClip palms;

	public AudioSource audioSource;

	void Start() {
		PlayPalms ();
	}
	public void PlayPalms()
	{
		audioSource.clip = palms;
		Play();
	}

	void Play()
	{
		audioSource.Play();

	}
}
