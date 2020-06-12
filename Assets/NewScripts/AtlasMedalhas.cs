using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

enum SpriteMedalhas {flat_0, flat_1, flat_2, flat_3, flat_4, flat_5, flat_6, flat_7, flat_8}

public class AtlasMedalhas : MonoBehaviour {

	//s[SerializeField]
	//private SpriteObj currettype;
	//private Spritetype lasttype;
	public GameObject btP, btN;
	public bool ch;
	private string[] v = { "flat_0", "flat_1", "flat_2", "flat_3", "flat_4", "flat_5", "flat_6", "flat_7", "flat_8"};

	//public int c;
	private string b;


	[SerializeField]
	private SpriteAtlas atlas;

	private SpriteRenderer myRenderer;
	SoundPlayer soundPlayer;

	void Start () {
		myRenderer = GetComponent<SpriteRenderer>();
		inicializar ();
		soundPlayer = FindObjectOfType<SoundPlayer>();
	}


	void Update () {

		ChangeSprite ();
	}


	public void ChangeSprite(){
		b = v [manda.n];
		myRenderer.sprite = atlas.GetSprite (b);
	}


	public void inicializar(){
		if (ch){
			manda.n = 0;
			btP.SetActive (!(btP).activeInHierarchy);//desativando o botão previous
		}

	}

	public void previous(){
		soundPlayer.PlayPrevious ();
		manda.n -= 1;
		if (manda.n == 0) {
			btP.SetActive (!(btP).activeInHierarchy);//desativando o botão previous
		} else if (manda.n!=0 && manda.n!=8 ){
			btP.SetActive (true);
			btN.SetActive (true);//desativando o botão previous
		}
	}
	public void next(){
		soundPlayer.PlayNext ();
		manda.n += 1;
		if (manda.n == 8) {
			btN.SetActive (!(btN).activeInHierarchy);
		} else if (manda.n!=0 && manda.n!=8 ){
			btP.SetActive (true);
			btN.SetActive (true);//desativando o botão previous
		}

	}
}
