using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Pontuacao : MonoBehaviour {
	public static int pontos;
	public Text pontosTXT;


	// Use this for initialization
	void Start () {
		//pontos = 0;

		pontos = PlayerPrefs.GetInt ("pontos", pontos);

	}
	
	// Update is called once per frame
	void Update () {
		
		pontosTXT.text = pontos.ToString ();
		PlayerPrefs.SetInt ("pontos", pontos);

	}


}
