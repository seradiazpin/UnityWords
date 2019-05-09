using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMaster : MonoBehaviour {


	public string WriteWord = "";
	public static Dictionary<string,int> Balloons = new Dictionary<string,int>();
	public Text Posibles;
	public InputField InputWord;
	// Use this for initialization
	void Start () {
		Posibles = GameObject.FindGameObjectWithTag ("PosiblesPalabras").GetComponent<Text>();
		InputWord = GameObject.FindGameObjectWithTag ("Entradas").GetComponent<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Balloons.Count+", "+InputWord.text);
		if (Balloons.ContainsKey(InputWord.text)){
			GameObject[] palabras =  GameObject.FindGameObjectsWithTag("Palabra");
			foreach (var item in palabras) {
				var ball = item.GetComponent<balloon> ();
				if (ball.word.ToLower().Equals(InputWord.text.ToLower ())) {
					item.GetComponent<balloon> ().DestroyBalloon ();
					InputWord.text = "";
				}
			}
		}
		Posibles.text = GetKeys ();
	}
	public void AddBalloon(string word, int points){
		Balloons.Add(word, points);
	}
	public void RemoveBalloon(string word){
		Balloons.Remove (word);
	}

	string GetKeys(){
		string data = "";
		foreach (var item in Balloons) {
			data +=  item.Key +", ";
		}
		return data;
	}
}
