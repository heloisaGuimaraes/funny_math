using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grauDificuldade : MonoBehaviour {
	public Dropdown obj;

	// Use this for initialization
	void Start () {
		
		obj.value = manda.opcao;
		//print (manda.qtdMax);
		grau ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void grau(){

		if (obj.value == 0) {//fácil
			manda.opcao = 0;
			manda.qtdMax = 5;
		}else if (obj.value == 1) {//médio
			manda.opcao = 1;
			manda.qtdMax = 10;
		}else if (obj.value == 2) {//dificil
			manda.opcao = 2;
			manda.qtdMax = 15;
		}

		//print (manda.qtdMax);
	}
}
