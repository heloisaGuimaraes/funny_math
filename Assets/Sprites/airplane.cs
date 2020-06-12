using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class airplane : MonoBehaviour {

	public AudioClip plane;
	public AudioSource audioSource;

	private Rigidbody2D playerRb;
	public float velocidade;
	public GameObject biplane;
	public Sprite bA;
	public GameObject btBau;
	// Use this for initialization
	void Start () {
		playerRb = GetComponent <Rigidbody2D> ();
		Play ();

	}

	// Update is called once per frame
	void Update () {//se botar velocidade no y ele pula(eu acho)
		audioSource.loop = true;


			velocidade *= 1;//botao esquerdo

		playerRb.velocity = new Vector2(velocidade, playerRb.velocity.y);

		if (biplane.transform.position.x > 5f){
			audioSource.loop = false;
			Destroy (biplane);

		}
		if (biplane.transform.position.x > 0){
			btBau.SetActive (true);

		}

	}
	void Play(){
		audioSource.loop = true;
		audioSource.clip = plane;
		audioSource.Play();

	}

	public void bttBau(Button bau){
		bau.image.sprite = bA;
	}
}
