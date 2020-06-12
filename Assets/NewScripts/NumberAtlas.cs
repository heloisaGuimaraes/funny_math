using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class NumberAtlas : MonoBehaviour {

	private string[] v = { "n0", "n1", "n2", "n3", "n4", "n5", "n6", "n7", "n8", "n9"};

	private string b;


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
		b = v [manda.num];
		myRenderer.sprite = atlas.GetSprite (b);
	}
}
