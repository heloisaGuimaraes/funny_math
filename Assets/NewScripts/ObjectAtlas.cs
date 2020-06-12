using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

enum SpriteObj  {a_0, a_1, a_2, a_3, a_4, a_5, a_6, a_7, a_8, a_9, a_10, a_11, a_12, a_13, a_14, a_15, a_16, a_17, a_18, a_19, a_20, a_21, a_22, a_23, a_24, a_25, a_26, a_27, a_28}

public class ObjectAtlas : MonoBehaviour {


		[SerializeField]
	//private SpriteObj currettype;
		//private Spritetype lasttype;

	private string[] v = { "a_0", "a_1", "a_2", "a_3", "a_4", "a_5", "a_6", "a_7", "a_8", "a_9", "a_10", "a_11", "a_12", "a_13", "a_14", "a_15", "a_16", "a_17", "a_18", "a_19", "a_20", "a_21", "a_22", "a_23", "a_24", "a_25", "a_26", "a_27", "a_28"};
		
	//public int c;
	private string b;


		[SerializeField]
		private SpriteAtlas atlas;

		private SpriteRenderer myRenderer;


		void Start () {
			myRenderer = GetComponent<SpriteRenderer>();
			//myRenderer.sprite = atlas.GetSprite ("a_0");
			//lasttype = Spritetype.o;
			//c = Random.Range (0, 28);




		}


		void Update () {
			
			ChangeSprite ();
		}


		public void ChangeSprite(){
		b = v [manda.c];
		myRenderer.sprite = atlas.GetSprite (b);
	
			//	if (currettype != lasttype) {
			//myRenderer.sprite = atlas.GetSprite (currettype.ToString ());
			//		lasttype = currettype;
			//	}
		}
}