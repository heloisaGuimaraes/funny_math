using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

enum SpriteObjs  {a_0, a_1, a_2, a_3, a_4, a_5, a_6, a_7, a_8, a_9, a_10, a_11, a_12, a_13, a_14, a_15, a_16, a_17, a_18, a_19, a_20, a_21, a_22, a_23, a_24, a_25, a_26, a_27, a_28}

public class sorteioAtlas : MonoBehaviour {
	[SerializeField]
	private SpriteObjs currettype;
	//private Spritetype lasttype;

	private string[] vl = { "a_0", "a_1", "a_2", "a_3", "a_4", "a_5", "a_6", "a_7", "a_8", "a_9", "a_10", "a_11", "a_12", "a_13", "a_14", "a_15", "a_16", "a_17", "a_18", "a_19", "a_20", "a_21", "a_22", "a_23", "a_24", "a_25", "a_26", "a_27", "a_28"};


	private string b;
	public int pos;

	[SerializeField]
	private SpriteAtlas atlas;

	private SpriteRenderer myRenderer;


	void Start () {
		myRenderer = GetComponent<SpriteRenderer>();
	}


	void Update () {

		ChangeSprite ();
	}


	public void ChangeSprite(){
		b = vl [pos];
		myRenderer.sprite = atlas.GetSprite (b);
	}
}
