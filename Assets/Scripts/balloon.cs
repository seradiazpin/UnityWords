using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour {

	public float maxheigth = 100f;
	public GameObject text;
	public string word;
	public Transform textPosition;
	private Rigidbody2D rg;
	public GameMaster gm;
	public float speed = 30f;
	public Sprite pop; 
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		WiteText ();
	}
	
	// Update is called once per frame
	void Update () {
		rg.AddForce (new Vector2 (0.0f, speed));
		if (transform.position.y > maxheigth) {
			
			DestroyBalloon ();
		}
	}

	public void DestroyBalloon(){
		
		GetComponentInParent<MovTank> ().CurrentWords -= 1;
		gm.RemoveBalloon (word);
		Destroy (transform.gameObject);
	}

	void WiteText(){
		text.GetComponent<TextMesh> ().text = word;
		text.transform.localScale = new Vector3 (0.3f,0.3f,0.3f);
		Vector3 pos = new Vector3 (textPosition.position.x, textPosition.position.y - 5, textPosition.position.z -2);
			Instantiate (text, pos, Quaternion.identity, transform);
	}
}
